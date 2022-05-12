using UnityEngine;

namespace Pong.Core.Configurations
{
    [CreateAssetMenu(fileName = "PongSoundsConfig", menuName = "Configuration/PongSounds-Config", order = 4)]
    public class PongSoundsConfig : ScriptableObject
    {
        public AudioClip hitWall;
        public AudioClip hitPaddle;
        public AudioClip gameResult;
    }
}
