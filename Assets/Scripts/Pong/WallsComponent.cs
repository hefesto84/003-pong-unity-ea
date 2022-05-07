using System;
using UnityEngine;

namespace Pong
{
    public class WallsComponent : MonoBehaviour
    {
        private readonly WallComponent[] _limits = new WallComponent[4];
        
        private void Start()
        {
            //SetupWalls();
        }

        private void SetupWalls()
        {
            var cam = Camera.main;
            
            if (cam == null) throw new Exception("There is no camera set.");
            
            for (var i = 0; i < _limits.GetLength(0); i++)
            {
                _limits[i] = new GameObject().AddComponent<WallComponent>();
            }
           
            var size = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            
            _limits[0].Setup(new Vector2(0,size.y), new Vector2(size.x*2f, 0.1f), transform);
            _limits[1].Setup(new Vector2(0,-size.y), new Vector2(size.x*2f, 0.1f), transform);
            _limits[2].Setup(new Vector2(size.x,0), new Vector2(0.1f, size.y*2f), transform);
            _limits[3].Setup(new Vector2(-size.x,0), new Vector2(0.1f, size.y*2f), transform);
        }

        private void OnDestroy()
        {
            var length = _limits.GetLength(0);

            for (var i = 0; i < length; i++)
            {
                Destroy(_limits[i].gameObject);
            }
        }
    }
}
