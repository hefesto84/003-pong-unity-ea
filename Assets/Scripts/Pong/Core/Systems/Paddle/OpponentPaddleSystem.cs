using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Paddle.Base;

namespace Pong.Core.Systems.Paddle
{
    public class OpponentPaddleSystem : PaddleSystem
    {
        public OpponentPaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem) : base(configService, screenService, ballSystem, PlayerType.Opponent) { }

        
        public override void Update()
        {
            if (!ConfigService.PongConfig.isAIEnabled)
            {
                base.Update();
                return;
            }
            
            var ct = View.transform.position;
   
            ct.y = BallSystem.View.transform.position.y;

            if (ct.y > ScreenSize.y || ct.y < -ScreenSize.y) return;

            View.UpdateView(ct);
        }

        public override void Reset()
        {
            SetupView();
        }
    }
}