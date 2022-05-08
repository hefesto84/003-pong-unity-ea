using System;
using UnityEngine;

namespace Pong.Services
{
    public class ScreenService : MonoBehaviour
    {
        private Camera _camera;
        private int _currentScreenWidth = 0;
        private int _currentScreenHeight = 0;
        
        public Action OnScreenResized { get; set; }
        
        public void Init(Camera cam)
        {
            _currentScreenHeight = Screen.height;
            _currentScreenWidth = Screen.width;
            
            _camera = cam;
        }

        private void Update()
        {
            if (_currentScreenHeight == Screen.height && _currentScreenWidth == Screen.width) return;
            
            _currentScreenWidth = Screen.width;
            _currentScreenHeight = Screen.height;
            
            OnScreenResized?.Invoke();
        }
    }
}