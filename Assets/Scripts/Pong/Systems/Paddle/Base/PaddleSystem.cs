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
 
        protected PaddleSystem(ConfigService configService, ScreenService screenService, PaddleType paddleType)
        {
            _configService = configService;
            _screenService = screenService;

            _paddleType = paddleType;
            
            PaddleMovementSpeed = configService.PongConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
        }
 
        public virtual void Update(Bounds ballBounds){}
        public virtual void Reset(){}

        protected void SetupView()
        {
            if (PaddleView == null) PaddleView = new GameObject("Paddle").AddComponent<PaddleView>();

            PaddleView.Init(_configService, _screenService, _paddleType);
        }
        
        protected bool IsCollision(Bounds ballBounds)
        {
            return ballBounds.Intersects(PaddleView.Bounds);
        }
    }
}