using System;
using DG.Tweening;
using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.Core.Views.Base;
using UnityEngine;

namespace Pong.Core.Views
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
            
            var assetsConfig = configService.PongConfig.assetsConfig;
            
            SpriteRenderer.sprite = _playerType == PlayerType.Player ? assetsConfig.playerPaddleSprite : assetsConfig.opponentPlayerSprite;
            
            OnScreenResized(_screenService.CurrentSize);
        }

        public void UpdateView(float y, float reactionTime)
        {
            transform.DOMoveY(y,reactionTime);
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

        public void Reset()
        {
            var pt = transform.position;
            pt.y = 0;
            UpdateView(pt);
        }

        private void OnDestroy()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }
    }
}