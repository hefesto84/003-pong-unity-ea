using Pong.FSM.States.Base;
using Pong.Systems;

namespace Pong.FSM.States
{
    public class InitGameState : State
    {
        public InitGameState(GameSystem gameSystem) : base(gameSystem)
        {
            
        }
        
        public override void DoState()
        {
            GameSystem.SetState(GameSystem.GameState);
        }
    }
}