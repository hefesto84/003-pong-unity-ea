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
        private ScoreView _scoreView;
        private GameResultView _gameResultView;
        
        public void Init(ConfigService configService)
        {
            _configService = configService;
        }

        public void SetState(State state)
        {
            if (state.GetType() == typeof(InitGameState))
            {
                BuildViews();
            }
        }

        private void BuildViews()
        {
            _scoreView = Instantiate(_configService.PongConfig.scoreView).GetComponent<ScoreView>();
            _gameResultView = Instantiate(_configService.PongConfig.resultView).GetComponent<GameResultView>();

            _scoreView.name = "ScoreView";
            _gameResultView.name = "GameResultView";
            
            _scoreView.transform.SetParent(transform);
            _gameResultView.transform.SetParent(transform);
        }
    }
}
