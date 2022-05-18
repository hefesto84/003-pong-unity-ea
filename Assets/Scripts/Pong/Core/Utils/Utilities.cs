
using UnityEngine;

namespace Pong.Core.Utils
{
    public class Utilities
    {
        public int GetRandomNormalized => Random.Range(0, 2) * 2 - 1;
    }
}