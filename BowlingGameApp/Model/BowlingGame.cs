using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class BowlingGame
    {
        public BowlingGame()
        {
            ResetGame();
        }

        /// <summary>
        /// List containing the values of each played roll.
        /// </summary>
        public List<int> Rolls => GetRollsFromFrames(Frames);

        /// <summary>
        /// Contains objects representing a single turn.
        /// </summary>
        public List<Frame> Frames { get; protected set; } = new List<Frame>();

        /// <summary>
        /// Returns number of pins remaining this turn.
        /// </summary>
        public int RemainingPinsThisFrame => GetCurrentFrame().RemainingPins;

        /// <summary>
        /// Resets the state of the game.
        /// </summary>
        public void ResetGame()
        {
            ResetFrames();
            currentFrame = 0;
        }

        /// <summary>
        /// Adds the result of a roll to the game's score.
        /// </summary>
        /// <param name="points">Number of pins knocked down.</param>
        public bool AddRoll(int points)
        {
            if (points < 0 || points > GetCurrentFrame().RemainingPins) return false;

            foreach (var frame in Frames)
            {
                frame.AddBonusPoints(points);
            }

            GetCurrentFrame().AddRoll(points);

            if (!FrameIsCompleted(points)) return true;
            if (IsFinalFrame()) return true;
            GoToNextFrame();
            return true;
        }

        /// <summary>
        /// Calculates the game's final score.
        /// </summary>
        /// <returns>Integer representation of the game's final score.</returns>
        public int CalculateFinalScore() => GetCurrentFrame().RunningValue;

        private int currentFrame = 0;

        private void ResetFrames()
        {
            Frames.Clear();
            for (int frame = 0; frame < 10; frame++)
            {
                Frames.Add(new Frame(frame, Frames.ElementAtOrDefault(frame - 1)));
            }
        }

        private void GoToNextFrame()
        {
            currentFrame++;
        }

        private Frame GetCurrentFrame() => Frames[currentFrame];

        private int GetRollScore(int rollIndex)
        {
            return Rolls.ElementAtOrDefault(rollIndex);
        }

        private bool IsStrike(int rollIndex)
        {
            return GetRollScore(rollIndex) == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return GetRollScore(rollIndex) + GetRollScore(rollIndex + 1) == 10;
        }

        private int StrikeBonus(int rollIndex)
        {
            return GetRollScore(rollIndex + 1) + GetRollScore(rollIndex + 2);
        }

        private int SpareBonus(int rollIndex)
        {
            return GetRollScore(rollIndex + 2);
        }

        private List<int> GetRollsFromFrames(List<Frame> frames)
        {
            List<int> rolls = new List<int>();
            foreach (Frame frame in frames)
            {
                rolls.AddRange(frame.Scores);
            }
            return rolls;
        }

        private bool FrameIsCompleted(int value)
        {
            return Frames[currentFrame].Scores.Count >= 2 || value == 10;
        }

        private bool IsFinalFrame()
        {
            return currentFrame >= 9;
        }
    }
}
