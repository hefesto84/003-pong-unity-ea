using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Paddle.Base;
using UnityEngine;

namespace Pong.Core.Systems.Paddle
{
    public class PlayerPaddleSystem : PaddleSystem
    {
        public PlayerPaddleSystem(ConfigService configService, ScreenService screenService, BallSystem ballSystem) : base(configService, screenService, ballSystem, PlayerType.Player) { }

        public override void Reset()
        {
            View.Reset();
        }
    }
}