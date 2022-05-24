using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.UI.Views.Base;
using TMPro;
using UnityEngine;

namespace Pong.UI.Views.GameResult
{
    public class GameResultView : UIView
    {
        [SerializeField] private TextMeshProUGUI gameResultText;
        private ScoreService _scoreService;
        
        public void Init(ScoreService scoreService)
        {
            name = GetType().ToString();
            _scoreService = scoreService;
            _scoreService.OnPlayerWins += OnPlayerWins;
        }

        public override void Reset()
        {
            gameResultText.text = string.Empty;
        }
        
        private void OnPlayerWins(PlayerType obj)
        {
            gameResultText.text = $"{obj} wins.\n Press Space to Continue";
        }

        private void OnDestroy()
        {
            _scoreService.OnPlayerWins -= OnPlayerWins;
        }
    }
}