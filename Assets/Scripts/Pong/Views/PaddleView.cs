using System;
using Pong.Configurations;
using Pong.Services;
using UnityEngine;

namespace Pong.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PaddleView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private ScreenService _screenService;
        private Bounds _rendererBounds;
        private PaddleType _paddleType;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void Init(ConfigService configService, ScreenService screenService, PaddleType paddleType)
        {
            _screenService = screenService;
            _screenService.OnScreenResized += OnScreenResized;

            _paddleType = paddleType;
            _spriteRenderer.sprite = _paddleType == PaddleType.Player ? configService.PongConfig.playerPaddleSprite : configService.PongConfig.opponentPlayerSprite;
            
            _rendererBounds = _spriteRenderer.bounds;
            
            Debug.Log("B: "+_rendererBounds);
            OnScreenResized(_screenService.CurrentSize);
        }
        
        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            var pt = transform.position;
            pt.x = _paddleType == PaddleType.Player ? -screenSize.x + _rendererBounds.size.x*2 : screenSize.x - _rendererBounds.size.x*2;
            UpdateView(pt);
        }

        private void OnDestroy()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
    }
}