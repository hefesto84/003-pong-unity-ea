using Pong.Configurations;
using Pong.FSM.States.Base;
using Pong.Services;
using Pong.Systems;
using UnityEngine;

namespace Pong.FSM.States
{
    public class GameState : State
    {
        private readonly PongConfig _pongConfig;
        
        private bool IsPlaying { get; set; }
        private bool IsPaused { get; set; }

        public GameState(ConfigService configService, ScreenService screenService, GameSystem gameSystem) : base(gameSystem)
        {
            _pongConfig = configService.PongConfig;
        }
        
        public override void DoState()
        {
            switch (IsPlaying)
            {
                case true:
                    ProcessState();
                    return;
                case false:
                    ShowDependencies();
                    IsPlaying = true;
                    IsPaused = false;
                    break;
            }
        }

        private void ProcessState()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsPaused = !IsPaused;
            }

            if (!IsPaused)
            {
                Debug.Log("Playing...");
            }
        }
        
        private void ShowDependencies()
        {
            Debug.Log($"Game: {_pongConfig.victoryPoints}, {_pongConfig.initialBallSpeed}, {_pongConfig.paddleMovementSpeed}");
        }
    }
}