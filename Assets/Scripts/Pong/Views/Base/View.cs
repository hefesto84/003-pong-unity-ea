using System;
using UnityEngine;

namespace Pong.Views.Base
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class View : MonoBehaviour
    {
        public Bounds Bounds => SpriteRenderer.bounds;
        protected SpriteRenderer SpriteRenderer;
        protected bool IsViewInitialized = false;

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}