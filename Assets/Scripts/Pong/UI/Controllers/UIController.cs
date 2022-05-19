using Pong.Core.Services;
using Pong.Core.States.Base;
using Pong.UI.Views;
using UnityEngine;

namespace Pong.UI.Controllers
{
    [RequireComponent(typeof(UIViews))]
    public class UIController : MonoBehaviour
    {
        private UIViews _views;
      
        private void Awake()
        {
            _views = GetComponent<UIViews>();
        }

        public void Init(ConfigService configService, ScoreService scoreService)
        {
            _views.Init(configService, scoreService);
        }

        public void SetState(State state)
        {
            if (state.StateType == StateType.InitGameState)
            {
                _views.BuildViews();
                return;
            }
            
            _views.SetState(state);
        }
        
        public void Reset()
        {
            _views.Reset();
        }
    }
}
