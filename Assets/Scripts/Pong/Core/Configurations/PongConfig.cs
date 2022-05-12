using UnityEngine;

namespace Pong.Core.Configurations
{
    
    [CreateAssetMenu(fileName = "PongConfig", menuName = "Configuration/PongConfig", order = 1)]
    public class PongConfig : ScriptableObject
    {
        [Header("Gameplay Parameters\n")]
        public bool isAIEnabled = false;
        public PongDifficultyConfig difficultyConfig;
        public PongAssetsConfig assetsConfig;
        [Header("View prefabs\n")]
        public GameObject scoreView;
        public GameObject resultView;
        public GameObject separatorsView;
        [Header("Sounds\n")] 
        public PongSoundsConfig soundsConfig;
    }
}