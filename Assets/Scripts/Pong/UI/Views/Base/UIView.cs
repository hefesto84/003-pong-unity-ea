using Pong.Core.Services;
using UnityEngine;

namespace Pong.UI.Views.Base
{
    public abstract class UIView : MonoBehaviour
    {
        public virtual void Init(ScoreService scoreService){}
        public virtual void Reset(){}
    }
}
