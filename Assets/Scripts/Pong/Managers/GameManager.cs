using System;
using Pong.Configurations;
using Pong.FSM.States;
using Pong.FSM.States.Base;
using Pong.Services;
using UnityEngine;

namespace Pong.Systems
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
        
        public void Init(ConfigService configService, ScreenService screenService, BallSystem ballSystem)
        {
            _configService = configService;
            _screenService = screenService;

            _ballSystem = ballSystem;
            
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
            
            GameState = new GameState(_configService, _screenService, _ballSystem, this);

            _currentState = InitGameState;
            
            IsReady = true;
        }
    }
}