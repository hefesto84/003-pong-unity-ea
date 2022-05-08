using Pong.Services;
using Pong.Systems.Ball;
using UnityEngine;

namespace Pong.Systems.Game
{
    public class GameSystem
    {
        private ConfigService _configService;
        private ScreenService _screenService;
        private BallSystem _ballSystem;
        private Vector3 _screenSize;
        private Vector3 _currentBallPosition;
        
        public GameSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem)
        {
            _configService = configService;
            _screenService = screenService;
            _ballSystem = ballSystem;

            _screenService.OnScreenResized += OnScreenResized;
        }

        ~GameSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
        
        public void Reset()
        {
            _screenSize = _screenService.CurrentSize;
        }

        public void Update()
        {
            _currentBallPosition = _ballSystem.View.transform.position;

            if (!(_currentBallPosition.x < -_screenSize.x) && !(_currentBallPosition.x > _screenSize.x)) return;
            
            Debug.Log("POINT!");
            
            _ballSystem.Reset();
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
        }
    }
}