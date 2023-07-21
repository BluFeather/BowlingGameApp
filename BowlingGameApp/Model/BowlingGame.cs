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
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare(rollIndex))
                {
                    score += 10;
                    score += Rolls[rollIndex + 2];
                    rollIndex += 2;
                    continue;
                }

                score += Rolls[rollIndex] + Rolls[rollIndex + 1];
                rollIndex += 2;
            }

            return score;
        }

        private bool IsSpare(int rollIndex)
        {
            return Rolls[rollIndex] + Rolls[rollIndex + 1] == 10;
        }
    }
}
