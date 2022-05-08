using UnityEngine;

namespace Pong.Configurations
{
    
    [CreateAssetMenu(fileName = "PongConfig", menuName = "Configuration/PongConfig", order = 1)]
    public class PongConfig : ScriptableObject
    {
        public float paddleMovementSpeed = 3f;
        public float initialBallSpeed = 3f;
        public int victoryPoints = 3;
        public Sprite paddleSprite;
        public Sprite ballSprite;
    }
}