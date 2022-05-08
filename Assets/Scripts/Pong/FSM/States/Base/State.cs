using Pong.Systems;

namespace Pong.FSM.States.Base
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
        protected GameManager GameManager;
        
        protected State(GameManager gameManager)
        {
            GameManager = gameManager;
        }
        
        public abstract void DoState();
    }
}