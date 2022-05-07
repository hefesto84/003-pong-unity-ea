using System;
using UnityEngine;

namespace Pong
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerComponent : MonoBehaviour
    {
        [Range(1, 10)] [SerializeField] private int movementSpeed = 3;

        [SerializeField] private BallComponent ball;
        [SerializeField] private PaddleType paddleType;
        
        private Vector2 _direction;

        private Vector2 _size;
        private SpriteRenderer sp;
        private void Awake()
        {
            sp = GetComponent<SpriteRenderer>();
            SetInitialPosition();
        }

        private void Update()
        {
            var ct = transform.position;
            var inc = Input.GetAxis("Vertical");

            var np = inc * Time.deltaTime * movementSpeed;
            
            ct += new Vector3(0, np, 0);

            if (ct.y > 4 || ct.y < -4) return;

            transform.position = ct;
            
            
            Collides2();
        }

        private void SetInitialPosition()
        {
            _size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            transform.position = new Vector3(paddleType == PaddleType.Player ? -_size.x+1 : _size.x-1, 0, 0);
        }

        private void Collides2()
        {
            var ballPosition = ball.transform.position;
            var paddlePosition = transform.position;

            if (ball.GetComponent<SpriteRenderer>().bounds.Intersects(sp.bounds))
            {
                ball.Collided(paddleType);
            }
        }
    }
}
