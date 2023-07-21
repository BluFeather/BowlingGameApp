using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class BowlingGame
    {
        List<int> Rolls = new List<int>();

        public void Roll(int value)
        {
            Rolls.Add(value);
        }

        public int Score()
        {
            return Rolls.Sum();
        }
    }
}
