using System.Collections.Generic;
using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.UI.Views.Base;
using TMPro;
using UnityEngine;

namespace Pong.UI.Views
{
    public class ScoreView : UIView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private ScoreService _scoreService;
        private const string DefaultScoreText = "0 - 0";
        
        public override void Init(ScoreService scoreService)
        {
            name = GetType().ToString();
            
            _scoreService = scoreService;
            _scoreService.OnScoreUpdated += OnScoreUpdated;
            
            Reset();
        }

        private void OnScoreUpdated(Dictionary<PlayerType, int> score)
        {
            scoreText.text = $"{score[PlayerType.Player]} - {score[PlayerType.Opponent]}";
        }

        private void OnDestroy()
        {
            _scoreService.OnScoreUpdated -= OnScoreUpdated;
        }

        public override void Reset()
        {
            scoreText.text = DefaultScoreText;
        }
    }
}