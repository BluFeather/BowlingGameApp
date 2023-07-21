using System.Collections.Generic;

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
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10;
                    score += StrikeBonus(frameIndex);
                    frameIndex += 1;
                    continue;
                }

                if (IsSpare(frameIndex))
                {
                    score += 10;
                    score += SpareBonus(frameIndex);
                    frameIndex += 2;
                    continue;
                }

                score += Rolls[frameIndex] + Rolls[frameIndex + 1];
                frameIndex += 2;
            }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return Rolls[frameIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return Rolls[rollIndex] + Rolls[rollIndex + 1] == 10;
        }

        private int StrikeBonus(int frameIndex)
        {
            return Rolls[frameIndex + 1] + Rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return Rolls[frameIndex + 2];
        }  
    }
}
