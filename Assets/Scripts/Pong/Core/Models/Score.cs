using System.Collections.Generic;

namespace Pong.Core.Models
{
    public class Score
    {
        public List<ScoreEntry> Entries { get; private set; }

        public Score()
        {
            Entries = new List<ScoreEntry>();
        }
    }
}