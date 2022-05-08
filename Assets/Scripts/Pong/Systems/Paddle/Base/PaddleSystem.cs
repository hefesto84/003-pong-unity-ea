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
        private readonly PaddleType _paddleType;
        protected readonly float PaddleMovementSpeed;
        
        //private float ResizedX => _paddleType == PaddleType.Player ? -ScreenSize.x + 2f : ScreenSize.x - 2f;
        
        protected PaddleSystem(ConfigService configService, ScreenService screenService, PaddleType paddleType)
        {
            _configService = configService;
            _screenService = screenService;
            //_screenService.OnScreenResized += OnScreenResized;

            _paddleType = paddleType;
            
            PaddleMovementSpeed = configService.PongConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
        }
        
        ~PaddleSystem()
        {
            //_screenService.OnScreenResized -= OnScreenResized;
        }

        public virtual void Update(){}
        public virtual void Reset(){}

        protected void SetupView()
        {
            if (PaddleView == null) PaddleView = new GameObject("Paddle").AddComponent<PaddleView>();

            //PaddleView.transform.position = new Vector3(ResizedX, 0, 0);
            
            PaddleView.Init(_configService, _screenService, _paddleType);
        }
        
        /*
        private void OnScreenResized(Vector3 screenSize)
        {
            ScreenSize = screenSize;

            var pt = PaddleView.transform.position;
            pt.x = ResizedX;
            PaddleView.UpdateView(pt);
        }
        */
    }
}