using System;
using Pong.Configurations;
using Pong.Services;
using Pong.Systems;
using UnityEngine;

namespace Pong
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PongConfig pongConfig;

        private GameManager _gameManager;
        private BallSystem _ballSystem;

        private ConfigService _configService;
        private ScreenService _screenService;

        private void Start()
        {
            _gameManager = new GameObject("GameManager").AddComponent<GameManager>();
            _gameManager.transform.SetParent(transform);
            
            // Initialisation of the services
            InitServices();
            
            // Initialisation of the systems
            InitSystems();
            
            // Initialisation of the GameManager
            _gameManager.Init(_configService, _screenService, _ballSystem);
        }

        private void InitServices()
        {
            _configService = new GameObject("ConfigService").AddComponent<ConfigService>();
            _screenService = new GameObject("ScreenService").AddComponent<ScreenService>();
            
            _configService.Init(pongConfig);
            _screenService.Init(Camera.main);
            
            _configService.transform.SetParent(transform);
            _screenService.transform.SetParent(transform);
        }

        private void InitSystems()
        {
            _ballSystem = new BallSystem(_configService, _screenService);
        }

        private void OnDestroy()
        {
            _ballSystem = null;
        }
    }
}
