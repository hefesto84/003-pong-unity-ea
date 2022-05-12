using DG.Tweening;
using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Paddle.Base;
using UnityEngine;

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

            if (ct.y > ScreenSize.y - Bounds.size.y*0.5f || ct.y < -ScreenSize.y + Bounds.size.y*0.5f) return;

            View.UpdateView(ct.y, ReactionTime);
        }

        public override void Reset()
        {
            View.Reset();
            SetReactionTime();
        }
    }
}