using System.Collections.Generic;

namespace Pong.Models
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