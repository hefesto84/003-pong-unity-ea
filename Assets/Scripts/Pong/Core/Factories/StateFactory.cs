using System;
using System.Collections.Generic;
using Pong.Core.States.Base;

namespace Pong.Core.Factories
{
    public class StateFactory
    {
        private Dictionary<StateType, State> _states;
        
        public StateFactory()
        {
            
        }

        public void Init()
        {
            _states = new Dictionary<StateType, State>();
        }

        public void RegisterState(State state)
        {
            if (_states.ContainsKey(state.StateType)) return;
            
            _states.Add(state.StateType, state);
        }

        public State Get(StateType stateType)
        {
            if (!_states.ContainsKey(stateType)) throw new Exception("State not registered.");

            return _states[stateType];
        }
    }
}