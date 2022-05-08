using System;
using Pong.Configurations;
using UnityEngine;

namespace Pong.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PaddleView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void Init(PongConfig pongConfig, PaddleType paddleType)
        {
            _spriteRenderer.sprite = paddleType == PaddleType.Player ? pongConfig.playerPaddleSprite : pongConfig.opponentPlayerSprite;
        }
        
        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }
    }
}