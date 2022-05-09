using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using Pong.Core.Views;
using UnityEngine;

namespace Pong.Core.Systems.Paddle.Base
{
    public abstract class PaddleSystem : Systems.Base.System
    {
        public PaddleView View { get; private set; }
        public PlayerType PlayerType { get; private set; }

        protected readonly BallSystem BallSystem;
        private readonly ConfigService _configService;
        private readonly ScreenService _screenService;
        protected Vector3 ScreenSize;
        
        protected readonly float PaddleMovementSpeed;
        
        protected PaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem, PlayerType playerType)
        {
            _configService = configService;
            _screenService = screenService;
            
            BallSystem = ballSystem;

            PlayerType = playerType;
            
            PaddleMovementSpeed = configService.PongConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
        }

        public void CheckCollision()
        {
            if (BallSystem.View.Bounds.Intersects(View.Bounds))
            {
                BallSystem.IsCollided(PlayerType);
            }
        }

        protected void SetupView()
        {
            if (View == null) View = new GameObject("Paddle").AddComponent<PaddleView>();
            
            View.Init(_configService, _screenService, PlayerType);
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