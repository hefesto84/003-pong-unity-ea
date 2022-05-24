using Pong.Core.Factories;
using Pong.Core.States;
using Pong.Core.States.Base;
using Pong.UI.Systems;

namespace Pong.Core.Managers
{
    public class GameManager
    {
        private State _currentState;
        private bool IsReady { get; set; }

        private UISystem _uiSystem;
        public StateFactory StateFactory { get; private set; }

        public void Init(StateFactory stateFactory, UISystem uiSystem)
        {
            _uiSystem = uiSystem;
            StateFactory = stateFactory;
            
            CreateStatesAndSetDependencies();
        }
        
        public void SetState(State state)
        {
            _currentState?.Stop();
            _currentState = state;
            _currentState.Start();
            
            _uiSystem.SetState(state);
        }
        
        public void Update()
        {
            if (!IsReady) return;
            
            _currentState?.DoState();
        }

        private void CreateStatesAndSetDependencies()
        {
            IsReady = true;
        }
    }
}