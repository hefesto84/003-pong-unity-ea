using Pong.Managers;
using Pong.States.Base;

namespace Pong.States
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