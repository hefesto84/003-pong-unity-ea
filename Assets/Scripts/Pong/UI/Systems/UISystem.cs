using Pong.Core.Managers;
using Pong.Core.Services;
using Pong.Core.States.Base;
using Pong.UI.Controllers;
using UnityEngine;

namespace Pong.UI.Systems
{
    public class UISystem : Core.Systems.Base.System
    {
        private readonly UIController _uiController;
        
        public UISystem(ConfigService configService, UIController uiController)
        {
            _uiController = uiController;
            _uiController.Init(configService);
        }

        public override void Init()
        {
            Debug.Log("INITIALIZATION OF UISYSTEM");
        }

        public void SetState(State state)
        {
            _uiController.SetState(state);
        }
    }
}