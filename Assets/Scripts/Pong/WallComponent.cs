using System;
using UnityEngine;

namespace Pong
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WallComponent : MonoBehaviour
    {
        private BoxCollider2D _collider2D;
        
        private void Awake()
        {
            _collider2D = GetComponent<BoxCollider2D>();
        }

        public void Setup(Vector2 position, Vector2 size, Transform parent)
        {
            transform.position = position;
            _collider2D.size = size;
            transform.SetParent(parent);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
        }
    }
}
