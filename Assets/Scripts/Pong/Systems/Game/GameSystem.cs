using System.Collections.Generic;
using Pong.Configurations;
using Pong.Services;
using Pong.Systems.Ball;
using UnityEngine;

namespace Pong.Systems.Game
{
    public class GameSystem : Base.System
    {
        private ConfigService _configService;
        private ScreenService _screenService;
        private ScoreService _scoreService;
        private BallSystem _ballSystem;
        private Vector3 _screenSize;
        private Vector3 _currentBallPosition;

        private Dictionary<PlayerType, int> _currentScore;
        private PongConfig _pongConfig;

        public bool IsGameOver =>
            _currentScore[PlayerType.Player] == _pongConfig.victoryPoints ||
            _currentScore[PlayerType.Opponent] == _pongConfig.victoryPoints;

        public GameSystem(ConfigService configService, ScreenService screenService, ScoreService scoreService, BallSystem ballSystem)
        {
            _configService = configService;
            _screenService = screenService;
            _scoreService = scoreService;
            
            _ballSystem = ballSystem;

            _screenService.OnScreenResized += OnScreenResized;

            _currentScore = new Dictionary<PlayerType, int>();
            
            ResetScore();

            _pongConfig = _configService.PongConfig;
        }

        ~GameSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
        
        public override void Reset()
        {
            _screenSize = _screenService.CurrentSize;
            ResetScore();
        }

        public override void Update()
        {
            _currentBallPosition = _ballSystem.View.transform.position;

            if (!(_currentBallPosition.x < -_screenSize.x) && !(_currentBallPosition.x > _screenSize.x)) return;

            _currentScore[_currentBallPosition.x < -_screenSize.x ? PlayerType.Opponent : PlayerType.Player]++;
       
            _ballSystem.Reset();
            
            Debug.Log($"Player: {_currentScore[PlayerType.Player]}, Opponent: {_currentScore[PlayerType.Opponent]}");

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