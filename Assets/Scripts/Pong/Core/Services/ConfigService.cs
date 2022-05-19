using Pong.Core.Configurations;
using UnityEngine;

namespace Pong.Core.Services
{
    public class ConfigService
    {
        public PongConfig PongConfig { get; private set; }

        public void Init(PongConfig pongConfig)
        {
            PongConfig = pongConfig;
        }
    }
}