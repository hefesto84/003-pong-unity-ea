using Pong.Services;
using Pong.Views.Base;
using UnityEngine;

namespace Pong.Views
{
    public class PaddleView : View
    {
        private ScreenService _screenService;
        private PaddleType _paddleType;

        public void Init(ConfigService configService, ScreenService screenService, PaddleType paddleType)
        {
            _screenService = screenService;
            _screenService.OnScreenResized += OnScreenResized;

            _paddleType = paddleType;
            SpriteRenderer.sprite = _paddleType == PaddleType.Player ? configService.PongConfig.playerPaddleSprite : configService.PongConfig.opponentPlayerSprite;
            
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