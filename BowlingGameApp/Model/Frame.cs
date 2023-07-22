using System.Collections.Generic;

namespace BowlingGameApp.Model
{
    public class Frame
    {
        public Frame(List<int> hits, int score)
        {
            Hits = hits;
            Score = score;
        }

        public List<int> Hits { get; protected set; } = new List<int>();

        public int Score { get; protected set; }
    }
}
