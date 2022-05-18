using Pong.Core.Services;
using Pong.Core.States.Base;
using Pong.UI.Views.Base;
using Pong.UI.Views.GameResult;
using Pong.UI.Views.Score;
using Pong.UI.Views.Separator;
using UnityEngine;

namespace Pong.UI.Views
{
    public class UIViews : MonoBehaviour
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
        
        public void BuildViews()
        {
            var pongConfig = _configService.PongConfig;
            
            _scoreView = Instantiate(pongConfig.scoreView, transform).GetComponent<ScoreView>();
            _gameResultView = Instantiate(pongConfig.resultView, transform).GetComponent<GameResultView>();
            _separatorView = Instantiate(pongConfig.separatorsView, transform).GetComponent<SeparatorView>();

            _scoreView.Init(_configService, _scoreService);
            _gameResultView.Init(_scoreService);
            _separatorView.Init(_configService);
        }

        public void SetState(State state)
        {
            _gameResultView.gameObject.SetActive(state.StateType == StateType.GameOverState);
            _scoreView.gameObject.SetActive(state.StateType == StateType.GameState);
            _separatorView.gameObject.SetActive(state.StateType == StateType.GameState);
        }

        public void Reset()
        {
            _scoreView.Reset();
            _gameResultView.Reset();
            _separatorView.Reset();
        }
    }
}