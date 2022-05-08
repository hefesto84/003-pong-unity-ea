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
        private LimitsSystem _limitsSystem;

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
            _gameManager.Init(_configService, _screenService);
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
            _limitsSystem = new LimitsSystem(_screenService);
            _limitsSystem.Init();
        }
    }
}
