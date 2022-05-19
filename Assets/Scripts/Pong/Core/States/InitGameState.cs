using Pong.Core.Managers;
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
    public class InitGameState : State
    {
        private readonly BallSystem _ballSystem;
        private readonly PlayerPaddleSystem _playerPaddleSystem;
        private readonly OpponentPaddleSystem _opponentPaddleSystem;
        private readonly CollisionSystem _collisionSystem;
        private readonly GameSystem _gameSystem;
        private readonly UISystem _uiSystem;
        
        public InitGameState(
            BallSystem ballSystem, 
            PaddleSystem playerPaddleSystem,
            PaddleSystem opponentPaddleSystem,
            CollisionSystem collisionSystem,
            GameSystem gameSystem,
            UISystem uiSystem,
            GameManager gameManager) : base(gameManager, StateType.InitGameState)
        {
            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem as PlayerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem as OpponentPaddleSystem;
            _collisionSystem = collisionSystem;
            _gameSystem = gameSystem;
            _uiSystem = uiSystem;
        }

        public override void Start()
        {
            _ballSystem.Init();
            _playerPaddleSystem.Init();
            _opponentPaddleSystem.Init();
            _collisionSystem.Init();
            _gameSystem.Init();
            _uiSystem.Init();
        }

        public override void DoState()
        {
            ResetSystems();
        }

        private void ResetSystems()
        {
            _ballSystem.Reset();
            _playerPaddleSystem.Reset();
            _opponentPaddleSystem.Reset();
            _collisionSystem.Reset();
            _gameSystem.Reset();
            _uiSystem.Reset();
            
            GameManager.SetState(GameManager.StateFactory.Get(StateType.GameState));
        }
    }
}