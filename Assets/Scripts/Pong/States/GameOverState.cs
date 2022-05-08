using Pong.Managers;
using Pong.States.Base;
using UnityEngine;

namespace Pong.States
{
    public class GameOverState : State
    {
        public GameOverState(GameManager gameManager) : base(gameManager) { }

        public override void DoState()
        {
            Debug.Log("GAME OVER");
        }
    }
}