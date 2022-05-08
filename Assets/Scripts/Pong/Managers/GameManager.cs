using Pong.FSM.States;
using Pong.FSM.States.Base;
using Pong.Services;
using Pong.Systems;
using Pong.Systems.Ball;
using Pong.Systems.Paddle.Base;
using UnityEngine;

namespace Pong.Managers
{
    public class GameManager : MonoBehaviour
    {
        private State _currentState;

        public readonly GameOverState GameOverState;
        public InitGameState InitGameState { get; private set; }
        public GameState GameState { get; set; }

        private bool IsReady { get; set; }

        private ConfigService _configService;
        private ScreenService _screenService;

        private BallSystem _ballSystem;
        private PaddleSystem _playerPaddleSystem;
        private PaddleSystem _opponentPaddleSystem;
        
        public void Init(ConfigService configService, ScreenService screenService, BallSystem ballSystem, PaddleSystem playerPaddleSystem, PaddleSystem opponentPaddleSystem )
        {
            _configService = configService;
            _screenService = screenService;

            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem;
            
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
            Debug.Log("Setting dependencies...");
            
            InitGameState = new InitGameState(this);
            
            GameState = new GameState(_configService, _screenService, _ballSystem, _playerPaddleSystem, _opponentPaddleSystem, this);

            _currentState = InitGameState;
            
            IsReady = true;
        }
    }
}