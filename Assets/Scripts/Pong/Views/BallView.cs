using Pong.Configurations;
using Pong.Views.Base;
using UnityEngine;

namespace Pong.Views
{
    public class BallView : View
    {
        private Vector3 _screenSize;
 
        public void Init(PongConfig pongConfig)
        {
            SpriteRenderer.sprite = pongConfig.ballSprite;
        }

        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }
        
        public void Collided(PaddleType paddleType)
        {
            /*
            Debug.Log("COLLIDES!"+Time.deltaTime);
            switch (paddleType)
            {
                case PaddleType.Player:
                    dx *= -1;
                    break;
                default:
                    dx *= -1;
                    break;
            }*/
        }
        
    }
}
