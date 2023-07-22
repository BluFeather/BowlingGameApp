using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class BowlingGame
    {
        public List<int> Rolls => GetRollsFromFrames(Frames);

        public List<Frame> Frames { get; protected set; } = new List<Frame>();

        public int frameIndex = 0;

        private Frame GetCurrentFrame()
        {
            if (Frames.ElementAtOrDefault(frameIndex) == null)
            {
                Frames.Add(new Frame());
            }
            return Frames[frameIndex];
        }

        public void Roll(int value)
        {
            GetCurrentFrame().Hits.Add(value);

            foreach (var frame in Frames)
            {
                frame.AddMissingBonus(value);
            }

            if (!FrameIsCompleted(value)) return;
            if (IsFinalFrame()) return;
            frameIndex++;
        }

        public int CalculateFinalScore()
        {
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10;
                    score += StrikeBonus(rollIndex);
                    rollIndex += 1;
                    continue;
                }

                if (IsSpare(rollIndex))
                {
                    score += 10;
                    score += SpareBonus(rollIndex);
                    rollIndex += 2;
                    continue;
                }

                score += Rolls[rollIndex] + Rolls[rollIndex + 1];
                rollIndex += 2;
            }

            return score;
        }

        private bool IsStrike(int rollIndex)
        {
            return Rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return Rolls[rollIndex] + Rolls[rollIndex + 1] == 10;
        }

        private int StrikeBonus(int rollIndex)
        {
            return Rolls[rollIndex + 1] + Rolls[rollIndex + 2];
        }

        private int SpareBonus(int rollIndex)
        {
            return Rolls[rollIndex + 2];
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

        private bool FrameIsCompleted(int value)
        {
            return Frames[frameIndex].Hits.Count >= 2 || value == 10;
        }

        private bool IsFinalFrame()
        {
            return frameIndex >= 9;
        }
    }
}
