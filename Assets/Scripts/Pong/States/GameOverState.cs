using Pong.Managers;
using Pong.States.Base;

namespace Pong.States
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