using System;
using Pong.Views;
using UnityEngine;

namespace Pong
{
    public class PlayerComponent : MonoBehaviour
    {
        [Range(1, 10)] [SerializeField] private int movementSpeed = 3;

        [SerializeField] private BallView ball;
        [SerializeField] private PaddleType paddleType;
        
        private Vector2 _direction;

        private Vector2 _size;
        private SpriteRenderer sp;
        private Bounds _bounds;

        private SpriteRenderer paddleRenderer;
        private SpriteRenderer ballRenderer;
        
        private void Awake()
        {
            paddleRenderer = GetComponent<SpriteRenderer>();
            ballRenderer = ball.GetComponent<SpriteRenderer>();
            
            SetInitialPosition();
        }

        private void Update()
        {
            var ct = transform.position;
            var inc = Input.GetAxis("Vertical");

            var np = inc * Time.deltaTime * movementSpeed;
            
            ct += new Vector3(0, np, 0);

            //if (ct.y > 4 || ct.y < -4) return;

            transform.position = ct;
        }

        private void SetInitialPosition()
        {
            _size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            transform.position = new Vector3(paddleType == PaddleType.Player ? -_size.x+1 : _size.x-1, 0, 0);
        }

        private bool _isColliding = false;
        
    }
}
