using Pong.Services;
using Pong.Systems.Ball;
using Pong.Views;
using UnityEngine;

namespace Pong.Systems.Paddle.Base
{
    public abstract class PaddleSystem
    {
        public PaddleView View { get; private set; }
        public PaddleType PaddleType { get; private set; }

        protected readonly BallSystem BallSystem;
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        protected Vector3 ScreenSize;
        
        protected readonly float PaddleMovementSpeed;
        

        protected PaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem, PaddleType paddleType)
        {
            _configService = configService;
            _screenService = screenService;
            
            BallSystem = ballSystem;

            PaddleType = paddleType;
            
            PaddleMovementSpeed = configService.PongConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
        }
 
        public virtual void Update(){}
        public virtual void Reset(){}
        
        public void CheckCollision()
        {
            if (BallSystem.View.Bounds.Intersects(View.Bounds))
            {
                BallSystem.IsCollided(PaddleType);
            }
        }

        protected void SetupView()
        {
            if (View == null) View = new GameObject("Paddle").AddComponent<PaddleView>();
            
            View.Init(_configService, _screenService, PaddleType);
        }

        /*
        protected void CheckCollision()
        {
            if (_ballSystem.Bounds.Intersects(PaddleView.Bounds))
            {
                _ballSystem.IsCollided(_paddleType);
            }
        }
        */
    }
}