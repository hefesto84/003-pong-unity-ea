using Pong.Core.Services;
using Pong.Core.States;
using Pong.Core.States.Base;
using Pong.UI.Views;
using UnityEngine;

namespace Pong.UI.Controllers
{
    public class UIController : MonoBehaviour
    {
        private ConfigService _configService;
        private ScoreService _scoreService;
        private ScoreView _scoreView;
        private GameResultView _gameResultView;
        
        public void Init(ConfigService configService, ScoreService scoreService)
        {
            _configService = configService;
            _scoreService = scoreService;
        }

        public void SetState(State state)
        {
            if (state.GetType() == typeof(InitGameState))
            {
                BuildViews();
            }

            if (state.GetType() == typeof(GameState))
            {
                _gameResultView.gameObject.SetActive(false);
                _scoreView.gameObject.SetActive(true);
            }

            if (state.GetType() == typeof(GameOverState))
            {
                _gameResultView.gameObject.SetActive(true);
                _scoreView.gameObject.SetActive(false);
            }
        }

        private void BuildViews()
        {
            _scoreView = Instantiate(_configService.PongConfig.scoreView, transform).GetComponent<ScoreView>();
            _gameResultView = Instantiate(_configService.PongConfig.resultView, transform).GetComponent<GameResultView>();
            
            _scoreView.name = "ScoreView";
            _gameResultView.name = "GameResultView";
            
            _scoreView.Init(_scoreService);
            _gameResultView.Init(_scoreService);
        }
    }
}
