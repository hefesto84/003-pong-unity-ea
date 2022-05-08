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

        private GameSystem _gameSystem;

        private ConfigService _configService;
        private ScreenService _screenService;
        
        private void Start()
        {
            _gameSystem = new GameObject("GameSystem").AddComponent<GameSystem>();
            _gameSystem.transform.position = Vector3.zero;
            
            // Initialisation of the services
            _configService = new ConfigService(pongConfig);
            _screenService = new ScreenService(Camera.main);
            
            // Initialisation of the GameSystem
            _gameSystem.Init(_configService, _screenService);
        }
    }
}
