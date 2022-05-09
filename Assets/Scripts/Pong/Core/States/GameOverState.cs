using Pong.Core.Managers;
using Pong.Core.States.Base;
using UnityEngine;

namespace Pong.Core.States
{
    public class GameOverState : State
    {
        public GameOverState(GameManager gameManager) : base(gameManager) { }

        public override void DoState()
        {
            //Debug.Log("GAME OVER");
            
            ProcessState();
            //GameManager.SetState(GameManager.GameState);
        }

        private void ProcessState()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                GameManager.SetState(GameManager.GameState);
            }
        }
    }
}