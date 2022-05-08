using Pong.Configurations;

namespace Pong.Services
{
    public class ConfigService
    {
        public PongConfig PongConfig { get; }

        public ConfigService(PongConfig pongConfig)
        {
            PongConfig = pongConfig;
        }
    }
}