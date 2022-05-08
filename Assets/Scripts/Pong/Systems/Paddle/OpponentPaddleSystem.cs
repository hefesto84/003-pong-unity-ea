using Pong.Services;
using Pong.Systems.Ball;
using Pong.Systems.Paddle.Base;

namespace Pong.Systems.Paddle
{
    public class OpponentPaddleSystem : PaddleSystem
    {
        public OpponentPaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem) : base(configService, screenService, ballSystem, PaddleType.Opponent) { }

        public override void Update()
        {
            var ct = View.transform.position;
            //var inc = Input.GetAxis("Vertical");

            //var np = inc * Time.deltaTime * PaddleMovementSpeed;

            ct.y = BallSystem.View.transform.position.y;
        
            /*
            ct += new Vector3(0, np, 0);
            */
            
            if (ct.y > ScreenSize.y || ct.y < -ScreenSize.y) return;

            View.UpdateView(ct);
            
        }

        public override void Reset()
        {
            SetupView();
        }
    }
}