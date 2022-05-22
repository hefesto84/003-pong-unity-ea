using System;
using System.Collections.Generic;
using Pong.Core.States.Base;

namespace Pong.Core.Factories
{
    public class StateFactory
    {
        private Dictionary<StateType, State> _states;

        public void Init()
        {
            _states = new Dictionary<StateType, State>();
        }

        public void RegisterState(State state)
        {
            // We are using just single operation
            var result = _states.TryAdd(state.StateType, state);
            
            if (!result)
            {
                throw new Exception("Value already registered");
            }
        }

        public State Get(StateType stateType)
        {
            // Using TryGetValue for using a single operation
            if (!_states.TryGetValue(stateType, out var state))
            {
                throw new Exception("State not registered.");
            }

            return state;
        }
    }
}