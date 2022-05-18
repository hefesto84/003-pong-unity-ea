using System;
using System.Collections.Generic;
using Pong.Core.Enums;
using UnityEngine;

namespace Pong.Core.Services
{
    public class ScoreService
    {
        private ConfigService _configService;
        
        public Action<Dictionary<PlayerType,int>> OnScoreUpdated { get; set; }
        public Action<PlayerType> OnPlayerWins { get; set; }
        
        public PlayerType LastPlayerScored { get; private set; }
        
        public void Init(ConfigService configService)
        {
            _configService = configService;
            LastPlayerScored = PlayerType.None;
        }
        
        public void SetScore(Dictionary<PlayerType,int> score, PlayerType lastPlayerScored)
        {
            LastPlayerScored = lastPlayerScored;
           
            OnScoreUpdated?.Invoke(score);
            
            if(score[PlayerType.Player] == _configService.PongConfig.difficultyConfig.victoryPoints) OnPlayerWins?.Invoke(PlayerType.Player);
            if(score[PlayerType.Opponent] == _configService.PongConfig.difficultyConfig.victoryPoints) OnPlayerWins?.Invoke(PlayerType.Opponent);
        }
    }
}