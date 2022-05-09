using UnityEngine;

namespace Pong.Core.Configurations
{
    
    [CreateAssetMenu(fileName = "PongConfig", menuName = "Configuration/PongConfig", order = 1)]
    public class PongConfig : ScriptableObject
    {
        public bool isAIEnabled = false;
        public float paddleMovementSpeed = 3f;
        public float initialBallSpeed = 3f;
        public int victoryPoints = 3;
        public Sprite playerPaddleSprite;
        public Sprite opponentPlayerSprite;
        public Sprite ballSprite;
    }
}