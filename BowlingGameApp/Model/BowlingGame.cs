using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class BowlingGame
    {
        public List<int> Rolls => GetRollsFromFrames(Frames);

        public List<Frame> Frames { get; protected set; } = new List<Frame>();

        public int currentFrame = 0;

        public void Roll(int value)
        {
            if (Frames.ElementAtOrDefault(currentFrame) == null)
            {
                Frames.Add(new Frame());
            }

            Frames[currentFrame].Hits.Add(value);

            if (currentFrame >= 9) return;

            if (value == 10)
            {
                currentFrame++;
                return;
            }

            if (Frames[currentFrame].Hits.Count >= 2)
            {
                currentFrame++;
                return;
            }
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

        public void ResetGame()
        {
            Frames.Clear();
            for (int frame = 0; frame < 10; frame++)
            {
                Frames.Add(new Frame());
            }
        }

        private List<int> GetRollsFromFrames(List<Frame> frames)
        {
            List<int> rolls = new List<int>();
            foreach (Frame frame in frames)
            {
                rolls.AddRange(frame.Hits);
            }
            return rolls;
        }
    }
}
