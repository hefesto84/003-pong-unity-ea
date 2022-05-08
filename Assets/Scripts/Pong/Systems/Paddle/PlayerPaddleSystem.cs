using Pong.Services;
using Pong.Systems.Paddle.Base;
using UnityEngine;

namespace Pong.Systems.Paddle
{
    public class PlayerPaddleSystem : PaddleSystem
    {
        public PlayerPaddleSystem(ConfigService configService, ScreenService screenService) : base(configService, screenService, PaddleType.Player) { }

        public override void Update()
        {
            var ct = PaddleView.transform.position;
            var inc = Input.GetAxis("Vertical");

            var np = inc * Time.deltaTime * PaddleMovementSpeed;
            
            ct += new Vector3(0, np, 0);

            if (ct.y > ScreenSize.y || ct.y < -ScreenSize.y) return;

            PaddleView.UpdateView(ct);
        }

        public override void Reset()
        {
            SetupView();
        }
    }
}