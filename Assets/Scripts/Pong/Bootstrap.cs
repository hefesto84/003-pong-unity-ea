using System;
using Pong.Core.Configurations;
using Pong.Core.Managers;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Collision;
using Pong.Core.Systems.Game;
using Pong.Core.Systems.Paddle;
using Pong.UI.Views;
using UnityEngine;

namespace Pong
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PongConfig pongConfig;
        [SerializeField] private UIScoreView scoreView;
        [SerializeField] private UIGameResultView gameResultView;
        
        private GameManager _gameManager;
        
        private BallSystem _ballSystem;
        private PlayerPaddleSystem _playerPaddleSystem;
        private OpponentPaddleSystem _opponentPaddleSystem;
        private CollisionSystem _collisionSystem;
        private GameSystem _gameSystem;

        private ConfigService _configService;
        private ScreenService _screenService;
        private ScoreService _scoreService;

        private void Start()
        {
            _gameManager = new GameObject("GameManager").AddComponent<GameManager>();
            _gameManager.transform.SetParent(transform);
            
            // Initialisation of the services
            InitServices();
            
            // Initialisation of the systems
            InitSystems();

            // Initialisation of the UI
            InitUI();
            
            // Initialisation of the GameManager
            _gameManager.Init(
                _configService, 
                _screenService, 
                _ballSystem, 
                _playerPaddleSystem, 
                _opponentPaddleSystem, 
                _collisionSystem, 
                _gameSystem);
        }

        private void InitServices()
        {
            _configService = new GameObject("ConfigService").AddComponent<ConfigService>();
            _screenService = new GameObject("ScreenService").AddComponent<ScreenService>();
            _scoreService = new GameObject("ScoreService").AddComponent<ScoreService>();
            
            _configService.Init(pongConfig);
            _screenService.Init(Camera.main);
            _scoreService.Init(_configService);
            
            _configService.transform.SetParent(transform);
            _screenService.transform.SetParent(transform);
        }

        private void InitSystems()
        {
            _ballSystem = new BallSystem(_configService, _screenService);
            _playerPaddleSystem = new PlayerPaddleSystem(_configService, _screenService, _ballSystem);
            _opponentPaddleSystem = new OpponentPaddleSystem(_configService, _screenService, _ballSystem);
            _collisionSystem = new CollisionSystem(_ballSystem, _playerPaddleSystem, _opponentPaddleSystem);
            _gameSystem = new GameSystem(_configService, _screenService, _scoreService, _ballSystem);
        }

        private void InitUI()
        {
            scoreView.Init(_scoreService);
            gameResultView.Init(_scoreService);
        }
        
        private void OnDestroy()
        {
            _ballSystem = null;
            _playerPaddleSystem = null;
            _opponentPaddleSystem = null;
            _collisionSystem = null;
        }
    }
}
