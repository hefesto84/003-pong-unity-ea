using Pong.Services;
using Pong.Views;
using UnityEngine;

namespace Pong.Systems.Paddle.Base
{
    public abstract class PaddleSystem
    {
        protected PaddleView PaddleView;

        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        protected Vector3 ScreenSize;
        private PaddleType _paddleType;
        protected float PaddleMovementSpeed;
        
        protected PaddleSystem(ConfigService configService, ScreenService screenService, PaddleType paddleType)
        {
            _configService = configService;
            _screenService = screenService;
            _screenService.OnScreenResized += OnScreenResized;

            _paddleType = paddleType;
            
            PaddleMovementSpeed = configService.PongConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
        }
        
        ~PaddleSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }

        public abstract void Update();
        public abstract void Reset();

        protected void SetupView()
        {
            if (PaddleView == null) PaddleView = new GameObject("Paddle").AddComponent<PaddleView>();

            PaddleView.transform.position = new Vector3(_paddleType == PaddleType.Player ? -ScreenSize.x : ScreenSize.x, 0, 0);
            
            PaddleView.Init(_configService.PongConfig, _paddleType);
        }
        
        private void OnScreenResized(Vector3 screenSize)
        {
            ScreenSize = screenSize;

            var pt = PaddleView.transform.position;
            pt.x = _paddleType == PaddleType.Player ? -ScreenSize.x : ScreenSize.x;
            PaddleView.UpdateView(pt);
        }
    }
}