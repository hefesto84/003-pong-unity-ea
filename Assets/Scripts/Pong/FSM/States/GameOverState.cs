using Pong.FSM.States.Base;
using Pong.Systems;

namespace Pong.FSM.States
{
    public class GameOverState : State
    {
        public GameOverState(GameManager gameManager) : base(gameManager) { }

        public override void DoState()
        {
            throw new System.NotImplementedException();
        }
    }
}