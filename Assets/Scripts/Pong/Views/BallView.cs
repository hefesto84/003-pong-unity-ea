using Pong.Configurations;
using UnityEngine;

namespace Pong.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BallView : MonoBehaviour
    {
        private Vector3 _screenSize;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Init(PongConfig pongConfig)
        {
            _spriteRenderer.sprite = pongConfig.ballSprite;
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
