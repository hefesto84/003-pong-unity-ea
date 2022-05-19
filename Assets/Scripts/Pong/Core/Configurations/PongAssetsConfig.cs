using UnityEngine;

namespace Pong.Core.Configurations
{
    [CreateAssetMenu(fileName = "PongConfig", menuName = "Configuration/PongAssetsConfig", order = 2)]
    public class PongAssetsConfig : ScriptableObject
    {
        public Sprite playerPaddleSprite;
        public Sprite opponentPlayerSprite;
        public Sprite ballSprite;
        public Sprite separatorSprite;
        public Color32 verticalBarSpriteColor;
        public Color32 bottomBarSpriteColor;
        public Color32 topBarSpriteColor;
    }
}
