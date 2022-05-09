using Pong.Core.Managers;
using UnityEngine;

namespace Pong.Core.States.Base
{
    /*
    public abstract class State
    {
        public IEnumerator Start()
        {
            yield break;
        }

        public IEnumerator Bootstrap()
        {
            yield break;    
        }

        public IEnumerator Game()
        {
            yield break;
        }
    }*/
    public abstract class State
    {
        protected readonly GameManager GameManager;
        
        protected State(GameManager gameManager)
        {
            GameManager = gameManager;
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