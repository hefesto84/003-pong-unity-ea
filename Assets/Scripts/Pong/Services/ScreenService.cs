using UnityEngine;

namespace Pong.Services
{
    public class ScreenService
    {
        private Camera _camera;

        public ScreenService(Camera camera)
        {
            _camera = camera;
        }
    }
}