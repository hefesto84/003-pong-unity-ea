using Pong.Core.Managers;
using Pong.Core.States.Base;
using UnityEngine;

namespace Pong.Core.States
{
    public class GameOverState : State
    {
        public GameOverState(GameManager gameManager) : base(gameManager, StateType.GameOverState) { }

        public override void Start()
        {
            base.Start();
            Debug.Log("GAME OVER");
        }

        public override void DoState()
        {
            ProcessState();
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