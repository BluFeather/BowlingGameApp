using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class Frame
    {
        public Frame()
        {
        }

        public List<int> Hits { get; protected set; } = new List<int>();

        public int Score
        {
            get
            {
                return Hits.Sum();
            }
        }
    }
}
