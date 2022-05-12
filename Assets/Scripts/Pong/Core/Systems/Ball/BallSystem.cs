using System;
using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Views;
using Pong.Core.Views.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong.Core.Systems.Ball
{
    /* TODO: remove dependency of OnScreenResized */
    public class BallSystem : Base.System
    {
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        private readonly ScoreService _scoreService;
        
        private BallView _view;
        private Vector3 _screenSize;

        private float _dx = 8f;
        private float _dy = 8f;
        private float _dt = 0f;
        private Transform _ct;
        private Vector3 _cp;

        public View View => _view;

        private int InitialDirection => Random.Range(0, 2) * 2 - 1;

        public BallSystem(ConfigService configService, ScoreService scoreService, ScreenService screenService)
        {
            _configService = configService;
            _scoreService = scoreService;
            _screenService = screenService;
            _screenService.OnScreenResized += OnScreenResized;
        }

        ~BallSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }

        public override void Init()
        {
            SetupBallView();
        }

        public override void Reset()
        {
            _view.transform.position = Vector3.zero;
            
            _dt = Time.deltaTime;

            var initialDirection = GetInitialDirection();
            
            _dx = _configService.PongConfig.difficultyConfig.initialBallSpeed * initialDirection[0];
            _dy = _configService.PongConfig.difficultyConfig.initialBallSpeed * initialDirection[1];
            _ct = _view.transform;
            
            _screenSize = _screenService.CurrentSize;
        }

        private int[] GetInitialDirection()
        {
            if (_scoreService.LastPlayerScored == PlayerType.None)
            {
                return new[]
                {
                    Random.Range(0, 2) * 2 - 1,
                    Random.Range(0, 2) * 2 - 1
                };
            }

            return new[]
            {
                _scoreService.LastPlayerScored == PlayerType.Player ? 1 : -1,
                Random.Range(0, 2) * 2 - 1
            };
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

            if (_cp.y > _screenSize.y || _cp.y < -_screenSize.y)
            {
                _cp.y = _cp.y > _screenSize.y ? _screenSize.y : -_screenSize.y;
                _dy *= -1;
                _view.PlaySound(SoundType.Wall);
            }

            _view.UpdateView(_cp);
        }

        public void IsCollided(PlayerType playerType, Bounds paddleBounds)
        {
            _dx *= -1.01f;
            _dy *= 1f;

            _dy += Math.Abs(_cp.y - paddleBounds.center.y) * 2f;
     
            _cp.x += playerType == PlayerType.Player ? 0.1f : -0.1f;
            
            _view.UpdateView(_cp);
            _view.PlaySound(SoundType.Paddle);
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
        }
    }
}