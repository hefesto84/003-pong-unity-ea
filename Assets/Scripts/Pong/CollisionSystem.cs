using UnityEngine;

namespace Pong
{
    public class CollisionSystem : MonoBehaviour
    {
        [SerializeField] private PlayerComponent paddle1;
        [SerializeField] private PlayerComponent paddle2;
        [SerializeField] private BallComponent ball;

        private void Update()
        {
            CheckCollision();
        }

        private void CheckCollision()
        {
            
        }
    }
}