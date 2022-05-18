using System.Collections.Generic;
using Pong.Core.Configurations;
using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using UnityEngine;

namespace Pong.Core.Systems.Game
{
    public class GameSystem : Base.System
    {
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        private readonly ScoreService _scoreService;
        private readonly BallSystem _ballSystem;
        private Vector3 _screenSize;
        private Vector3 _currentBallPosition;

        private Dictionary<PlayerType, int> _currentScore;
        private PongConfig _pongConfig;

        public bool IsGameOver =>
            _currentScore[PlayerType.Player] == _pongConfig.difficultyConfig.victoryPoints ||
            _currentScore[PlayerType.Opponent] == _pongConfig.difficultyConfig.victoryPoints;

        public GameSystem(ConfigService configService, ScreenService screenService, ScoreService scoreService, BallSystem ballSystem)
        {
            _configService = configService;
            _screenService = screenService;
            _scoreService = scoreService;
            
            _ballSystem = ballSystem;
        }

        ~GameSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }

        public override void Init()
        {
            _screenService.OnScreenResized += OnScreenResized;

            _currentScore = new Dictionary<PlayerType, int>();
            
            _pongConfig = _configService.PongConfig;
            
            ResetScore();
        }

        public override void Reset()
        {
            _screenSize = _screenService.CurrentSize;
            ResetScore();
        }

        public override void Update()
        {
            _currentBallPosition = _ballSystem.View.transform.position;

            if (!(_currentBallPosition.x < -_screenSize.x) && !(_currentBallPosition.x > _screenSize.x))
            {
                return;
            }

            var playerScoreFrom = _currentBallPosition.x < -_screenSize.x ? PlayerType.Opponent : PlayerType.Player;
            
            _currentScore[playerScoreFrom]++;
            
            _scoreService.SetScore(_currentScore, playerScoreFrom);
            
            _ballSystem.Reset();
        }

        private void ResetScore()
        {
            _currentScore[PlayerType.Player] = 0;
            _currentScore[PlayerType.Opponent] = 0;
        }
        
        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
        }
    }
}