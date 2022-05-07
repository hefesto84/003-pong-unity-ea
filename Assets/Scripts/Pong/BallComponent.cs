using System;
using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace Pong
{
    public class BallComponent : MonoBehaviour
    {
        [Range(0,10f)]
        [SerializeField]
        private float _dx = 5f;
        [Range(0,10f)]
        [SerializeField]
        private float _dy = 5f;

        private Vector3 _screenSize;
        
        private void Awake()
        {
            _screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        }

        void Update()
        {
            var dt = Time.deltaTime;
            var ct = transform;
            var cp = ct.position;
            
            if (cp.y > _screenSize.y)
            {
                cp.y = _screenSize.y;
                _dy *= -1;
            }

            if (cp.y < -_screenSize.y)
            {
                cp.y = -_screenSize.y;
                _dy *= -1;
            }

            if (cp.x > _screenSize.x)
            {
                cp.x = _screenSize.x;
                _dx *= -1;
            }

            if (cp.x < -_screenSize.x)
            {
                cp.x = -_screenSize.x;
                _dx *= -1;
            }
            
            cp.x += _dx * dt;
            cp.y += _dy * dt;
            
            ct.position = cp;
        }

        public void Collided(PaddleType paddleType)
        {
            switch (paddleType)
            {
                case PaddleType.Player:
                    _dx *= -1;
                    break;
                default:
                    _dx *= -1;
                    break;
            }
        }
        
    }
}
