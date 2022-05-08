using Pong.Services;
using Pong.Views;
using UnityEngine;

namespace Pong.Systems.Ball
{
    /* TODO: remove dependency of OnScreenResized */
    public class BallSystem
    {
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        private BallView _ball;
        private Vector3 _screenSize;

        private float _dx = 8f;
        private float _dy = 8f;
        
        public Bounds Bounds => _ball.Bounds;
        
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
            SetupBallView();
            
            _dx = _configService.PongConfig.initialBallSpeed;
            _dy = _configService.PongConfig.initialBallSpeed;

            _screenSize = _screenService.CurrentSize;
        }

        private void SetupBallView()
        {
            if (_ball == null) _ball = new GameObject("Ball").AddComponent<BallView>();
            _ball.transform.position = Vector3.zero;
            _ball.Init(_configService.PongConfig);
        }
        
        public void Update()
        {
            var dt = Time.deltaTime;
            var ct = _ball.transform;
            var cp = ct.position;
            
            cp.x += _dx * dt;
            cp.y += _dy * dt;

            if (cp.y > _screenSize.y)
            {
                cp.y = _screenSize.y;
                _dy *= -1;
            }

            if (cp.y < -_screenSize.y)
            {
                cp.y = -_screenSize.y;
                _dy *= -1;
            }

            if (cp.x > _screenSize.x)
            {
                cp.x = _screenSize.x;
                _dx *= -1;
            }

            if (cp.x < -_screenSize.x)
            {
                cp.x = -_screenSize.x;
                _dx *= -1;
            }

            _ball.UpdateView(cp);
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
        }
    }
}