using System;
using System.Collections.Generic;
using Pong.Core.Enums;
using UnityEngine;

namespace Pong.Core.Services
{
    public class ScoreService : MonoBehaviour
    {
        private ConfigService _configService;
        
        public Action<Dictionary<PlayerType,int>> OnScoreUpdated { get; set; }
        public Action<PlayerType> OnPlayerWins { get; set; }
        
        public void Init(ConfigService configService)
        {
            _configService = configService;
        }
        
        public void SetScore(Dictionary<PlayerType,int> score)
        {
            OnScoreUpdated?.Invoke(score);
            
            if(score[PlayerType.Player] == _configService.PongConfig.victoryPoints) OnPlayerWins?.Invoke(PlayerType.Player);
            if(score[PlayerType.Opponent] == _configService.PongConfig.victoryPoints) OnPlayerWins?.Invoke(PlayerType.Opponent);
        }
    }
}