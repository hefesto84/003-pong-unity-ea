using Pong.Core.Services;
using Pong.Core.States;
using Pong.Core.States.Base;
using Pong.Core.Systems.Ball;
using Pong.Core.Systems.Collision;
using Pong.Core.Systems.Game;
using Pong.Core.Systems.Paddle.Base;
using Pong.UI.Systems;
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
        private UISystem _uiSystem;
        
        public void Init(ConfigService configService, 
            ScreenService screenService, 
            BallSystem ballSystem, 
            PaddleSystem playerPaddleSystem, 
            PaddleSystem opponentPaddleSystem,
            CollisionSystem collisionSystem,
            GameSystem gameSystem,
            UISystem uiSystem)
        {
            _configService = configService;
            _screenService = screenService;

            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem;
            _collisionSystem = collisionSystem;
            _gameSystem = gameSystem;
            _uiSystem = uiSystem;

            SetDependencies();
        }
        
        public void SetState(State state)
        {
            _currentState?.Stop();
            _currentState = state;
            _currentState.Start();
            
            _uiSystem.SetState(state);
        }
        
        private void Update()
        {
            if (!IsReady) return;
            
            _currentState?.DoState();
        }

        private void SetDependencies()
        {
            InitGameState = new InitGameState(_ballSystem, _playerPaddleSystem, _opponentPaddleSystem, _collisionSystem, _gameSystem, _uiSystem, this);
            
            GameState = new GameState(_configService, _screenService, _ballSystem, _playerPaddleSystem, _opponentPaddleSystem, _collisionSystem, _gameSystem, _uiSystem, this);

            GameOverState = new GameOverState(this);
            
            SetState(InitGameState);
            
            IsReady = true;
        }

        private void InitSystems()
        {
            
        }
    }
}