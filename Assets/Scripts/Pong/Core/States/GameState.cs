using Pong.Core.Configurations;
using Pong.Core.Managers;
using Pong.Core.Services;
using Pong.Core.States.Base;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Collision;
using Pong.Core.Systems.Game;
using Pong.Core.Systems.Paddle;
using Pong.Core.Systems.Paddle.Base;
using Pong.UI.Systems;
using UnityEngine;

namespace Pong.Core.States
{
    public class GameState : State
    {
        private readonly BallSystem _ballSystem;
        private readonly PlayerPaddleSystem _playerPaddleSystem;
        private readonly OpponentPaddleSystem _opponentPaddleSystem;
        private readonly CollisionSystem _collisionSystem;
        private readonly GameSystem _gameSystem;
        private readonly UISystem _uiSystem;
        private readonly PongConfig _pongConfig;
        
        private bool IsPlaying { get; set; }
        private bool IsPaused { get; set; }

        public GameState(
            ConfigService configService, 
            ScreenService screenService, 
            BallSystem ballSystem, 
            PaddleSystem playerPaddleSystem,
            PaddleSystem opponentPaddleSystem,
            CollisionSystem collisionSystem,
            GameSystem gameSystem,
            UISystem uiSystem,
            GameManager gameManager) : base(gameManager, StateType.GameState)
        {
            _pongConfig = configService.PongConfig;
            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem as PlayerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem as OpponentPaddleSystem;
            _collisionSystem = collisionSystem;
            _gameSystem = gameSystem;
            _uiSystem = uiSystem;
        }

        public override void DoState()
        {
            if (IsPlaying)
            {
                ProcessState();
                return;
            }
            
            ResetSystems();
            IsPlaying = true;
            IsPaused = false;
        }

        private void ProcessState()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsPaused = !IsPaused;
            }

            if (IsPaused)
            {
                return;
            }
            
            UpdateSystems();

            CheckMatchConditions();
        }

        private void UpdateSystems()
        {
            _ballSystem.Update();
            _playerPaddleSystem.Update();
            _opponentPaddleSystem.Update();
            _collisionSystem.Update();
            _gameSystem.Update();
            _uiSystem.Update();
        }
        
        private void CheckMatchConditions()
        {
            if (!_gameSystem.IsGameOver)
            {
                return;
            }
            
            GameManager.SetState(GameManager.StateFactory.Get(StateType.GameOverState));
            
            IsPaused = false;
            IsPlaying = false;
        }
        
        private void ResetSystems()
        {
            _ballSystem.Reset();
            _playerPaddleSystem.Reset();
            _opponentPaddleSystem.Reset();
            _collisionSystem.Reset();
            _gameSystem.Reset();
            _uiSystem.Reset();
        }
    }
}