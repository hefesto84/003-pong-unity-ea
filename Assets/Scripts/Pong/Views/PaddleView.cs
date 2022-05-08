using Pong.Services;
using Pong.Views.Base;
using UnityEngine;

namespace Pong.Views
{
    public class PaddleView : View
    {
        private ScreenService _screenService;
        private PlayerType _playerType;

        public void Init(ConfigService configService, ScreenService screenService, PlayerType playerType)
        {
            _screenService = screenService;
            _screenService.OnScreenResized += OnScreenResized;

            _playerType = playerType;
            SpriteRenderer.sprite = _playerType == PlayerType.Player ? configService.PongConfig.playerPaddleSprite : configService.PongConfig.opponentPlayerSprite;
            
            OnScreenResized(_screenService.CurrentSize);
        }
        
        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            var pt = transform.position;
            pt.x = _playerType == PlayerType.Player ? -screenSize.x + Bounds.size.x*2 : screenSize.x - Bounds.size.x*2;
            UpdateView(pt);
        }

        private void OnDestroy()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
    }
}