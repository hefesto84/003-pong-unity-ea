using System.Collections.Generic;
using Pong.Configurations;
using Pong.Managers;
using Pong.Services;
using Pong.States.Base;
using Pong.Systems.Ball;
using Pong.Systems.Collision;
using Pong.Systems.Game;
using Pong.Systems.Paddle;
using Pong.Systems.Paddle.Base;
using UnityEngine;

namespace Pong.States
{
    public class GameState : State
    {
        private readonly BallSystem _ballSystem;
        private readonly PlayerPaddleSystem _playerPaddleSystem;
        private readonly OpponentPaddleSystem _opponentPaddleSystem;
        private readonly CollisionSystem _collisionSystem;
        private readonly GameSystem _gameSystem;
        private readonly PongConfig _pongConfig;
        
        private bool IsPlaying { get; set; }
        private bool IsPaused { get; set; }

        private List<Systems.Base.System> _systems;
        
        public GameState(
            ConfigService configService, 
            ScreenService screenService, 
            BallSystem ballSystem, 
            PaddleSystem playerPaddleSystem,
            PaddleSystem opponentPaddleSystem,
            CollisionSystem collisionSystem,
            GameSystem gameSystem,
            GameManager gameManager) : base(gameManager)
        {
            _pongConfig = configService.PongConfig;
            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem as PlayerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem as OpponentPaddleSystem;
            _collisionSystem = collisionSystem;
            _gameSystem = gameSystem;

            _systems = new List<Systems.Base.System>
            {
                _ballSystem,
                _playerPaddleSystem,
                _opponentPaddleSystem,
                _collisionSystem,
                _gameSystem
            };
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
            
            UpdateSystems();

            CheckMatchConditions();
        }

        private void UpdateSystems()
        {
            foreach (var system in _systems) system.Update();
        }
        
        private void CheckMatchConditions()
        {
            if (_gameSystem.IsGameOver)
            {
                Debug.Log("BYE");
                GameManager.SetState(GameManager.GameOverState);
                IsPaused = false;
                IsPlaying = false;
            }
        }

        private void InitDependencies()
        {
            foreach (var system in _systems) system.Reset();
        }
        
        private void ShowDependencies()
        {
            Debug.Log($"Game: {_pongConfig.victoryPoints}, {_pongConfig.initialBallSpeed}, {_pongConfig.paddleMovementSpeed}");
        }
    }
}