﻿using Pong.Core.Managers;
using Pong.Core.States.Base;
using UnityEngine;

namespace Pong.Core.States
{
    public class GameOverState : State
    {
        public GameOverState(GameManager gameManager) : base(gameManager, StateType.GameOverState) { }

        public override void DoState()
        {
            ProcessState();
        }

        private void ProcessState()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameManager.SetState(GameManager.StateFactory.Get(StateType.GameState));
            }
        }
    }
}