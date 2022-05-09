using Pong.Core.Services;
using Pong.Core.States.Base;
using Pong.UI.Views;
using Pong.UI.Views.Base;
using UnityEngine;

namespace Pong.UI.Controllers
{
    public class UIController : MonoBehaviour
    {
        private ConfigService _configService;
        private ScoreService _scoreService;
        private UIView _scoreView;
        private UIView _gameResultView;
        
        public void Init(ConfigService configService, ScoreService scoreService)
        {
            _configService = configService;
            _scoreService = scoreService;
        }

        public void SetState(State state)
        {
            if (state.StateType == StateType.InitGameState)
            {
                BuildViews();
                return;
            }
            
            _gameResultView.gameObject.SetActive(state.StateType == StateType.GameOverState);
            _scoreView.gameObject.SetActive(state.StateType == StateType.GameState);
        }

        private void BuildViews()
        {
            _scoreView = Instantiate(_configService.PongConfig.scoreView, transform).GetComponent<ScoreView>();
            _gameResultView = Instantiate(_configService.PongConfig.resultView, transform).GetComponent<GameResultView>();

            _scoreView.Init(_scoreService);
            _gameResultView.Init(_scoreService);
        }

        public void Reset()
        {
            _scoreView.Reset();
            _gameResultView.Reset();
        }
    }
}
