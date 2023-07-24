using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class BowlingGame
    {
        public BowlingGame()
        {
            NewGame();
        }

        /// <summary>
        /// List containing the values of each played roll.
        /// </summary>
        public List<int> PlayedRolls
        {
            get
            {
                List<int> rolls = new();
                foreach (Frame frame in Frames)
                {
                    rolls.AddRange(frame.Scores);
                }
                return rolls;
            }
        }

        /// <summary>
        /// Contains objects representing a single turn.
        /// </summary>
        public List<Frame> Frames { get; protected set; } = new List<Frame>();

        /// <summary>
        /// Returns number of remaining pins in this frame.
        /// </summary>
        public int RemainingPins => CurrentFrame.RemainingPins;

        /// <summary>
        /// Zero-Based Integer representing the current roll to be scored in this frame.
        /// </summary>
        public int CurrentRoll => CurrentFrame.CurrentRoll;

        /// <summary>
        /// Readies this game for a new match.
        /// </summary>
        public void NewGame()
        {
            ResetFrames();
            frameIndex = 0;
        }

        /// <summary>
        /// Adds the result of a roll to the game's score.
        /// </summary>
        /// <param name="points">Number of pins knocked down.</param>
        /// <returns>bool indicating whether or not the roll was considered valid and added to the current frame.</returns>
        public bool AddRoll(int points)
        {
            if (points < 0 || points > CurrentFrame.RemainingPins) return false;

            foreach (var frame in Frames)
            {
                frame.AddBonusPoints(points);
            }

            CurrentFrame.TryAddRoll(points);

            if (!CurrentFrame.FrameIsComplete) return true;
            if (CurrentFrame.IsFinalFrame) return true;
            GoToNextFrame();
            return true;
        }

        /// <summary>
        /// The player's current score.
        /// </summary>
        /// <returns>Integer representation of the current score.</returns>
        public int Score => CurrentFrame.OverallScore;

        private int frameIndex = 0;

        private Frame CurrentFrame => Frames[frameIndex];

        private void ResetFrames()
        {
            Frames.Clear();
            for (int frame = 0; frame < 10; frame++)
            {
                Frames.Add(new Frame(frame == 9, Frames.ElementAtOrDefault(frame - 1)));
            }
        }

        private void GoToNextFrame()
        {
            frameIndex++;
        }
    }
}
