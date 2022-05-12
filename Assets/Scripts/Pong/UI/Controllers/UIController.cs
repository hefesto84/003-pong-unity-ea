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
        private UIView _separatorView;
        
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
            _separatorView.gameObject.SetActive(state.StateType == StateType.GameState);
        }

        private void BuildViews()
        {
            var config = _configService.PongConfig;
            
            _scoreView = Instantiate(config.scoreView, transform).GetComponent<ScoreView>();
            _gameResultView = Instantiate(config.resultView, transform).GetComponent<GameResultView>();
            _separatorView = Instantiate(config.separatorsView, transform).GetComponent<SeparatorView>();

            _scoreView.Init(_configService, _scoreService);
            _gameResultView.Init(_scoreService);
            _separatorView.Init(_configService);
        }

        public void Reset()
        {
            _scoreView.Reset();
            _gameResultView.Reset();
            _separatorView.Reset();
        }
    }
}
