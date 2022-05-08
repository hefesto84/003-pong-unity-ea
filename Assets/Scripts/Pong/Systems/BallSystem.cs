using Pong.Services;
using UnityEngine;

namespace Pong.Systems
{
    public class BallSystem
    {
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        private BallComponent _ball;
        private readonly LimitsSystem _limitsSystem;
        private Vector3 _screenSize;
        
        public float dx = 8f;
        public float dy = 8f;
        
        public BallSystem(ConfigService configService, ScreenService screenService)
        {
            _configService = configService;
            _screenService = screenService;
            _screenService.OnScreenResized += OnScreenResized;
        }

        ~BallSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
        
        public void Reset()
        {
            if (_ball == null) _ball = new GameObject("Ball").AddComponent<BallComponent>();
            
            _ball.transform.position = Vector3.zero;
            
            _ball.Init(_configService.PongConfig);
            
            dx = _configService.PongConfig.initialBallSpeed;
            dy = _configService.PongConfig.initialBallSpeed;

            _screenSize = _screenService.CurrentSize;
        }

        public void Update()
        {
            var dt = Time.deltaTime;
            var ct = _ball.transform;
            var cp = ct.position;
            
            cp.x += dx * dt;
            cp.y += dy * dt;

            
            
            if (cp.y > _screenSize.y)
            {
                cp.y = _screenSize.y;
                dy *= -1;
            }

            if (cp.y < -_screenSize.y)
            {
                cp.y = -_screenSize.y;
                dy *= -1;
            }

            if (cp.x > _screenSize.x)
            {
                cp.x = _screenSize.x;
                dx *= -1;
            }

            if (cp.x < -_screenSize.x)
            {
                cp.x = -_screenSize.x;
                dx *= -1;
            }

            ct.position = cp;
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
        }
    }
}