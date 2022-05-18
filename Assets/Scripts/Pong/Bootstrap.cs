using Pong.Core.Configurations;
using Pong.Core.Managers;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Collision;
using Pong.Core.Systems.Game;
using Pong.Core.Systems.Paddle;
using Pong.Core.Utils;
using Pong.UI.Controllers;
using Pong.UI.Systems;
using Unity.VisualScripting;
using UnityEngine;

namespace Pong
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PongConfig pongConfig;

        [SerializeField] private Transform canvas;

        private Utilities _utilities;
        private GameManager _gameManager;
        
        private BallSystem _ballSystem;
        private PlayerPaddleSystem _playerPaddleSystem;
        private OpponentPaddleSystem _opponentPaddleSystem;
        private CollisionSystem _collisionSystem;
        private GameSystem _gameSystem;
        private UISystem _uiSystem;

        private ConfigService _configService;
        private ScreenService _screenService;
        private ScoreService _scoreService;

        private UIController _uiController;

        private void Start()
        {
            _gameManager = new GameObject("GameManager").AddComponent<GameManager>();
            _gameManager.transform.SetParent(transform);
            
            // Initialisation of the utilities
            InitUtilities();
            
            // Initialisation of the services
            InitServices();
            
            // Build controllers
            BuildControllers();
            
            // Build systems
            BuildSystems();

            // Initialisation of the GameManager
            _gameManager.Init(
                _configService, 
                _screenService, 
                _ballSystem, 
                _playerPaddleSystem, 
                _opponentPaddleSystem, 
                _collisionSystem, 
                _gameSystem,
                _uiSystem);
        }

        private void InitUtilities()
        {
            _utilities = new Utilities();
        }

        private void BuildControllers()
        {
            _uiController = canvas.AddComponent<UIController>();
        }
        
        private void InitServices()
        {
            _configService = new ConfigService();
            _scoreService = new ScoreService();
            _screenService = new GameObject("ScreenService").AddComponent<ScreenService>();
            
            _configService.Init(pongConfig);
            _screenService.Init(Camera.main);
            _scoreService.Init(_configService);
            
            _screenService.transform.SetParent(transform);
        }

        private void BuildSystems()
        {
            _ballSystem = new BallSystem(_configService, _scoreService, _screenService, _utilities);
            _playerPaddleSystem = new PlayerPaddleSystem(_configService, _screenService, _ballSystem);
            _opponentPaddleSystem = new OpponentPaddleSystem(_configService, _screenService, _ballSystem);
            _collisionSystem = new CollisionSystem(_ballSystem, _playerPaddleSystem, _opponentPaddleSystem);
            _gameSystem = new GameSystem(_configService, _screenService, _scoreService, _ballSystem);
            _uiSystem = new UISystem(_configService, _scoreService, _uiController);
        }

        private void OnDestroy()
        {
            _ballSystem = null;
            _playerPaddleSystem = null;
            _opponentPaddleSystem = null;
            _collisionSystem = null;
            _uiSystem = null;
            _configService = null;
            _scoreService = null;
        }
    }
}
