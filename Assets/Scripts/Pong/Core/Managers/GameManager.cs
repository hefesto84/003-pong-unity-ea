using Pong.Core.Services;
using Pong.Core.States;
using Pong.Core.States.Base;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Collision;
using Pong.Core.Systems.Game;
using Pong.Core.Systems.Paddle.Base;
using UnityEngine;

namespace Pong.Core.Managers
{
    public class GameManager : MonoBehaviour
    {
        private State _currentState;

        public GameOverState GameOverState { get; private set; }
        public InitGameState InitGameState { get; private set; }
        public GameState GameState { get; private set; }

        private bool IsReady { get; set; }

        private ConfigService _configService;
        private ScreenService _screenService;

        private BallSystem _ballSystem;
        private PaddleSystem _playerPaddleSystem;
        private PaddleSystem _opponentPaddleSystem;
        private CollisionSystem _collisionSystem;
        private GameSystem _gameSystem;
        
        public void Init(ConfigService configService, 
            ScreenService screenService, 
            BallSystem ballSystem, 
            PaddleSystem playerPaddleSystem, 
            PaddleSystem opponentPaddleSystem,
            CollisionSystem collisionSystem,
            GameSystem gameSystem)
        {
            _configService = configService;
            _screenService = screenService;

            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem;
            _collisionSystem = collisionSystem;
            _gameSystem = gameSystem;

            SetDependencies();
        }
        
        public void SetState(State state)
        {
            _currentState = state;
        }
        
        private void Update()
        {
            if (!IsReady) return;
            
            _currentState?.DoState();
        }

        private void SetDependencies()
        {
            InitGameState = new InitGameState(this);
            
            GameState = new GameState(_configService, _screenService, _ballSystem, _playerPaddleSystem, _opponentPaddleSystem, _collisionSystem, _gameSystem, this);

            GameOverState = new GameOverState(this);
            
            _currentState = InitGameState;
            
            IsReady = true;
        }
    }
}