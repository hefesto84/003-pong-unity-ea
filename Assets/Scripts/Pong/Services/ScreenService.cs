using System;
using UnityEngine;

namespace Pong.Services
{
    public class ScreenService : MonoBehaviour
    {
        private Camera _camera;
        private int _currentScreenWidth = 0;
        private int _currentScreenHeight = 0;
        public Vector3 CurrentSize { get; private set; }
        
        public Action<Vector3> OnScreenResized { get; set; }
        
        public void Init(Camera cam)
        {
            _currentScreenHeight = Screen.height;
            _currentScreenWidth = Screen.width;
            
            _camera = cam;
            
            UpdateCurrentScreenSize();
        }

        private void Update()
        {
            if (_currentScreenHeight == Screen.height && _currentScreenWidth == Screen.width) return;
            
            _currentScreenWidth = Screen.width;
            _currentScreenHeight = Screen.height;
            
            UpdateCurrentScreenSize();
            
            OnScreenResized?.Invoke(CurrentSize);
        }

        private void UpdateCurrentScreenSize()
        {
            CurrentSize = _camera.ScreenToWorldPoint(new Vector3(_currentScreenWidth, _currentScreenHeight));
        }
    }
}