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
        protected readonly ConfigService ConfigService;
        private readonly ScreenService _screenService;
        protected Vector3 ScreenSize;
        
        protected float PaddleMovementSpeed;
        protected Bounds Bounds;
        protected float ReactionTime = 0f;
        
        protected PaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem, PlayerType playerType)
        {
            ConfigService = configService;
            _screenService = screenService;
            
            BallSystem = ballSystem;
            PlayerType = playerType;
        }

        public override void Init()
        {
            PaddleMovementSpeed = ConfigService.PongConfig.difficultyConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
            
            SetupView();
        }

        private void SetupView()
        {
            if (View == null)
            {
                View = new GameObject(GetType().FullName).AddComponent<PaddleView>();
            }
            
            View.Init(ConfigService, _screenService, PlayerType);

            Bounds = View.Bounds;
        }

        protected void SetReactionTime()
        {
            ReactionTime = Random.Range(0f,ConfigService.PongConfig.difficultyConfig.maxReactionTime);
        }
    }
}