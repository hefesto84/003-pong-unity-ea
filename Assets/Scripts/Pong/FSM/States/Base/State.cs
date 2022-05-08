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
        protected GameSystem GameSystem;
        
        protected State(GameSystem gameSystem)
        {
            GameSystem = gameSystem;
        }
        
        public abstract void DoState();
    }
}