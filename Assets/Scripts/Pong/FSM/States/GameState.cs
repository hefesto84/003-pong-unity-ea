using Pong.Configurations;
using Pong.FSM.States.Base;
using Pong.Services;
using Pong.Systems;
using UnityEngine;

namespace Pong.FSM.States
{
    public class GameState : State
    {
        private BallSystem _ballSystem;
        private readonly PongConfig _pongConfig;
        
        private bool IsPlaying { get; set; }
        private bool IsPaused { get; set; }

        public GameState(ConfigService configService, ScreenService screenService, BallSystem ballSystem, GameManager gameManager) : base(gameManager)
        {
            _pongConfig = configService.PongConfig;
            _ballSystem = ballSystem;
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
                    InitDependencies();
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

            if (IsPaused) return;
            
            _ballSystem.Update();
            
        }

        private void InitDependencies()
        {
            _ballSystem.Reset();     
        }
        
        private void ShowDependencies()
        {
            Debug.Log($"Game: {_pongConfig.victoryPoints}, {_pongConfig.initialBallSpeed}, {_pongConfig.paddleMovementSpeed}");
        }
    }
}