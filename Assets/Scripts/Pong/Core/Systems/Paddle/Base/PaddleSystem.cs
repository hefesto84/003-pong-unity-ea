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
        
        protected PaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem, PlayerType playerType)
        {
            ConfigService = configService;
            _screenService = screenService;
            
            BallSystem = ballSystem;
            PlayerType = playerType;
        }

        public override void Init()
        {
            PaddleMovementSpeed = ConfigService.PongConfig.paddleMovementSpeed;

            ScreenSize = _screenService.CurrentSize;
            
            SetupView();
        }

        public override void Update()
        {
            var ct = View.transform.position;
            var inc = Input.GetAxis("Vertical");

            var np = inc * Time.deltaTime * PaddleMovementSpeed;
            
            ct += new Vector3(0, np, 0);

            if (ct.y > ScreenSize.y || ct.y < -ScreenSize.y) return;

            View.UpdateView(ct);
        }

        protected void SetupView()
        {
            if (View == null) View = new GameObject("Paddle").AddComponent<PaddleView>();
            
            View.Init(ConfigService, _screenService, PlayerType);
        }
    }
}