using Pong.Core.Configurations;
using Pong.Core.Views.Base;
using UnityEngine;

namespace Pong.Core.Views
{
    public class BallView : View
    {
        private Vector3 _screenSize;
        
        public void Init(PongConfig pongConfig)
        {
            if (IsViewInitialized) return;
            
            SpriteRenderer.sprite = pongConfig.ballSprite;

            IsViewInitialized = true;
        }

        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }
        
    }
}
