using System;
using System.Collections.Generic;
using Pong.Core.Enums;
using UnityEngine;

namespace Pong.Core.Services
{
    public class ScoreService : MonoBehaviour
    {
        public Action<Dictionary<PlayerType,int>> OnScoreUpdated { get; set; }
        
        public void Init()
        {
        }
        
        public void SetScore(Dictionary<PlayerType,int> score)
        {
            OnScoreUpdated?.Invoke(score);
        }
    }
}