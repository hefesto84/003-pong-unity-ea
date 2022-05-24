using Pong.Core.Configurations;
using Pong.Core.Services;
using Pong.UI.Views.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.UI.Views.Separator
{
    public class SeparatorView : UIView
    {
        private PongConfig _pongConfig;
        
        [SerializeField] private Image verticalBar;
        [SerializeField] private Image topBar;
        [SerializeField] private Image bottomBar;
        
        public void Init(ConfigService configService)
        {
            _pongConfig = configService.PongConfig;
            name = GetType().ToString();
            
            SetAssets();
        }

        private void SetAssets()
        {
            verticalBar.sprite = _pongConfig.assetsConfig.separatorSprite;
            topBar.sprite = _pongConfig.assetsConfig.separatorSprite;
            bottomBar.sprite = _pongConfig.assetsConfig.separatorSprite;
            
            verticalBar.color = _pongConfig.assetsConfig.verticalBarSpriteColor;
            topBar.color = _pongConfig.assetsConfig.topBarSpriteColor;
            bottomBar.color = _pongConfig.assetsConfig.bottomBarSpriteColor;
        }
    }
}
