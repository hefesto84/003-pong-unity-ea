using Pong.Core.Managers;
using Pong.Core.States.Base;

namespace Pong.Core.States
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