using Pong.Services;
using Pong.Systems.Paddle.Base;
using UnityEngine;

namespace Pong.Systems.Paddle
{
    public class OpponentPaddleSystem : PaddleSystem
    {
        public OpponentPaddleSystem(ConfigService configService, ScreenService screenService) : base(configService, screenService, PaddleType.Opponent) { }

        public override void Update(Bounds ballBounds)
        {
            var ct = PaddleView.transform.position;
            var inc = Input.GetAxis("Vertical");

            var np = inc * Time.deltaTime * PaddleMovementSpeed;
            
            ct += new Vector3(0, np, 0);

            if (ct.y > ScreenSize.y || ct.y < -ScreenSize.y) return;

            PaddleView.UpdateView(ct);
            
            if(IsCollision(ballBounds))
            {
                Debug.Log($"Collision: {GetType()}");
            }
        }

        public override void Reset()
        {
            SetupView();
        }
    }
}