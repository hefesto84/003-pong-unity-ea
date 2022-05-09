using Pong.Core.Managers;
using Pong.Core.States.Base;
using UnityEngine;

namespace Pong.UI.Systems
{
    public class UISystem : Core.Systems.Base.System
    {
        private State _currentState;
        
        public UISystem()
        {
            
        }
        
        public override void Update()
        {
            
        }

        public override void Reset()
        {
            
        }

        public void SetState(State state)
        {
            _currentState = state;
        }
    }
}