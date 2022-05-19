using UnityEngine;

namespace Pong.Core.Configurations
{
    [CreateAssetMenu(fileName = "PongConfig", menuName = "Configuration/PongDifficulty-Config", order = 3)]
    public class PongDifficultyConfig : ScriptableObject
    {
        public float maxReactionTime = 1f;
        public float paddleMovementSpeed = 3f;
        public float initialBallSpeed = 3f;
        public int victoryPoints = 3;
    }
}