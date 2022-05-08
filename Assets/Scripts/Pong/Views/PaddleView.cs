using Pong.Services;
using UnityEngine;

namespace Pong.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PaddleView : MonoBehaviour
    {
        public Bounds Bounds => _spriteRenderer.bounds;
        
        private SpriteRenderer _spriteRenderer;
        private ScreenService _screenService;
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
            
            OnScreenResized(_screenService.CurrentSize);
        }
        
        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            var pt = transform.position;
            pt.x = _paddleType == PaddleType.Player ? -screenSize.x + Bounds.size.x*2 : screenSize.x - Bounds.size.x*2;
            UpdateView(pt);
        }

        private void OnDestroy()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
    }
}