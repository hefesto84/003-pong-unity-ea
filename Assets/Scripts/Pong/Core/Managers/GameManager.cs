using Pong.Core.Factories;
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

        private UISystem _uiSystem;
        private StateFactory _stateFactory;

        public void Init(StateFactory stateFactory, UISystem uiSystem)
        {
            _uiSystem = uiSystem;
            _stateFactory = stateFactory;
            
            CreateStatesAndSetDependencies();
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

        private void CreateStatesAndSetDependencies()
        {
            InitGameState = _stateFactory.Get(StateType.InitGameState) as InitGameState;
            GameState = _stateFactory.Get(StateType.GameState) as GameState;
            GameOverState = _stateFactory.Get(StateType.GameOverState) as GameOverState;

            SetState(InitGameState);
            
            IsReady = true;
        }
    }
}