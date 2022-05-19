using System.Collections.Generic;
using Pong.Core.Enums;
using Pong.Core.Services;
using Pong.UI.Views.Base;
using TMPro;
using UnityEngine;

namespace Pong.UI.Views.Score
{
    [RequireComponent(typeof(AudioSource))]
    public class ScoreView : UIView
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private AudioSource _audioSource;
        private ScoreService _scoreService;
        private const string DefaultScoreText = "0 - 0";
        
        public override void Init(ConfigService configService, ScoreService scoreService)
        {
            name = GetType().ToString();
            
            _scoreService = scoreService;
            _scoreService.OnScoreUpdated += OnScoreUpdated;

            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = configService.PongConfig.soundsConfig.gameResult;
            
            Reset();
        }

        private void OnScoreUpdated(Dictionary<PlayerType, int> score)
        {
            scoreText.text = $"{score[PlayerType.Player]} - {score[PlayerType.Opponent]}";
            _audioSource.Play();
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