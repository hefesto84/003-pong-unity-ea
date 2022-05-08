using System;
using Pong.Configurations;
using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace Pong
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BallComponent : MonoBehaviour
    {
        private Vector3 _screenSize;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        }

        public void Init(PongConfig pongConfig)
        {
            _spriteRenderer.sprite = pongConfig.ballSprite;
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
