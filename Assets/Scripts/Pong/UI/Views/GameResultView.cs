using System;
using Pong.Core.Enums;
using Pong.Core.Services;
using TMPro;
using UnityEngine;

namespace Pong.UI.Views
{
    public class GameResultView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gameResultText;
        private ScoreService _scoreService;
        
        public void Init(ScoreService scoreService)
        {
            _scoreService = scoreService;
            _scoreService.OnPlayerWins += OnPlayerWins;
        }

        private void OnPlayerWins(PlayerType obj)
        {
            gameResultText.text = $"{obj} wins.";
        }

        private void OnDestroy()
        {
            _scoreService.OnPlayerWins -= OnPlayerWins;
        }
    }
}