using Pong.Services;
using UnityEngine;

namespace Pong.Systems
{
    public class LimitsSystem
    {
        private readonly ScreenService _screenService;
        
        public LimitsSystem(ScreenService screenService)
        {
            _screenService = screenService;
        }

        public void Init()
        {
            RegisterCallbacks();
        }

        ~LimitsSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }

        private void RegisterCallbacks()
        {
            _screenService.OnScreenResized += OnScreenResized;
        }

        private void OnScreenResized()
        {
            Debug.Log("Screen resized detected in limits.");
        }
    }
}