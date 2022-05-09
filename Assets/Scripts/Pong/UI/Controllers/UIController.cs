using Pong.Core.Services;
using UnityEngine;

namespace Pong.UI.Controllers
{
    public class UIController : MonoBehaviour
    {
        private ConfigService _configService;
        
        public void Init(ConfigService configService)
        {
            _configService = configService;
        }
    }
}
