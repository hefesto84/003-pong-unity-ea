using Pong.Core.Managers;
using UnityEngine;

namespace Pong.Core.States.Base
{
    public enum StateType
    {
        InitGameState,
        GameState,
        GameOverState,
    }
    
    public abstract class State
    {
        protected readonly GameManager GameManager;
        
        public StateType StateType { get; private set; }
        
        protected State(GameManager gameManager, StateType stateType)
        {
            GameManager = gameManager;
            StateType = stateType;
        }

        public virtual void Start()
        {
            Debug.Log($"{GetType()} Start");
        }
        
        public abstract void DoState();

        public virtual void Stop()
        {
            Debug.Log($"{GetType()} Stop");
        }
    }
}