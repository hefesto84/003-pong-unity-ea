using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Views;
using Pong.Core.Views.Base;
using UnityEngine;

namespace Pong.Core.Systems.Ball
{
    /* TODO: remove dependency of OnScreenResized */
    public class BallSystem : Base.System
    {
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        private BallView _view;
        private Vector3 _screenSize;

        private float _dx = 8f;
        private float _dy = 8f;
        private float _dt = 0f;
        private Transform _ct;
        private Vector3 _cp;
        
        public View View => _view;

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
        
        public override void Reset()
        {
            SetupBallView();
            
            _dx = _configService.PongConfig.initialBallSpeed;
            _dy = _configService.PongConfig.initialBallSpeed;
            _dt = Time.deltaTime;
            _ct = _view.transform;
            
            _screenSize = _screenService.CurrentSize;
        }

        private void SetupBallView()
        {
            if (_view == null) _view = new GameObject("Ball").AddComponent<BallView>();
            _view.transform.position = Vector3.zero;
            _view.Init(_configService.PongConfig);
        }

        public override void Update()
        {
            _dt = Time.deltaTime;
            _cp = _ct.position;
            
            _cp.x += _dx * _dt;
            _cp.y += _dy * _dt;
            
            if (_cp.y > _screenSize.y)
            {
                _cp.y = _screenSize.y;
                _dy *= -1;
            }

            if (_cp.y < -_screenSize.y)
            {
                _cp.y = -_screenSize.y;
                _dy *= -1;
            }
            
            _view.UpdateView(_cp);
        }

        public void IsCollided(PlayerType playerType)
        {
            switch (playerType)
            {
                case PlayerType.Player:
                    _dx *= -1;
                    break;
                default:
                    _dx *= -1;
                    break;
            }  
        }
        
        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
        }
    }
}