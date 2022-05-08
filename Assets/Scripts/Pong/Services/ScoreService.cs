using System;
using Pong.Models;
using UnityEngine;

namespace Pong.Services
{
    public class ScoreService : MonoBehaviour
    {
        private Score _score;

        public void Init()
        {
            _score = new Score();
        }
        
        public void SetScore(ScoreEntry entry)
        {
            _score.Entries.Add(entry);
        }
    }
}