using Pong.FSM.States.Base;
using Pong.Managers;
using Pong.Systems;

namespace Pong.FSM.States
{
    public class InitGameState : State
    {
        public InitGameState(GameManager gameManager) : base(gameManager)
        {
            
        }
        
        public override void DoState()
        {
            GameManager.SetState(GameManager.GameState);
        }
    }
}