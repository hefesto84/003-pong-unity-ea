using Pong.Services;
using UnityEngine;

namespace Pong.Systems
{
    public class LimitsSystem
    {
        private readonly ScreenService _screenService;
        private Vector3 _screenSize;
        
        public LimitsSystem(ScreenService screenService)
        {
            _screenService = screenService;
        }
        
        ~LimitsSystem()
        {
            _screenService.OnScreenResized -= OnScreenResized;
        }

        public void Init()
        {
            RegisterCallbacks();
        }

        public void CheckLimits(BallComponent ballComponent)
        {
            
        }
        
        private void RegisterCallbacks()
        {
            _screenService.OnScreenResized += OnScreenResized;
        }

        private void OnScreenResized(Vector3 screenSize)
        {
            _screenSize = screenSize;
            Debug.Log("Screen resized detected in limits.");
        }
    }
}