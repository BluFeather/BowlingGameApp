using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    /// <summary>
    /// Represents a single turn in bowling.
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// Frame that will contain a running total consisting of this frame's value on top of the previous frame's value.
        /// </summary>
        /// <param name="previousFrame">Frame to refer to when calculating a running total.</param>
        public Frame(bool isFinalFrame, Frame? previousFrame)
        {
            IsFinalFrame = isFinalFrame;
            this.previousFrame = previousFrame;
        }

        /// <summary>
        /// Roll scores determining the base value of this frame.
        /// </summary>
        public List<int> Scores { get; protected set; } = new List<int>();
        
        /// <summary>
        /// Overall value of this frame, including bonuses.
        /// </summary>
        public int Value
        {
            get
            {
                if (Scores.Count > 2) // Can only happen in 10th frame.
                {
                    return 10 + Bonuses.Sum();
                }
                return Scores.Sum() + Bonuses.Sum();
            } 
        }

        /// <summary>
        /// Overall points awarded at the time of playing this frame. Includes bonuses from rolls in following frames.
        /// </summary>
        public int OverallScore => previousFrame != null ? Value + previousFrame.OverallScore : Value;

        /// <summary>
        /// Number of pins remaining in this frame.
        /// </summary>
        public int RemainingPins { get; protected set; } = 10;

        /// <summary>
        /// Attempts to add the value of a roll to this frame.
        /// </summary>
        /// <param name="rollValue">Points to be awarded for this roll.</param>
        /// <returns>bool indicating whether or not the rollValue was considered valid.</returns>
        public bool TryAddRoll(int rollValue)
        {
            if (rollValue > RemainingPins) return false;
            Scores.Add(rollValue);
            RemainingPins -= rollValue;

            if (ThirdRollNeededForLastFrame)
            {
                RemainingPins = 10;
            }
            return true;
        }

        /// <summary>
        /// Adds points as a bonus to this frame's score, if it needs bonus points for a spare or strike.
        /// </summary>
        /// <param name="rollValue">bonus points to be added to this frame's value.</param>
        public void AddBonusPoints(int rollValue)
        {
            if (!NeedsBonusPoints()) return;
            Bonuses.Add(rollValue);
        }

        /// <summary>
        /// Indicates whether or not this frame begins with a Strike.
        /// </summary>
        /// <returns>bool indicating whether or not this frame begins with a Strike</returns>
        public bool IsStrike()
        {
            return Scores.ElementAtOrDefault(0) == 10;
        }

        /// <summary>
        /// Indicates whether or not this frame begins with a spare.
        /// </summary>
        /// <returns>bool indicating whether or not this frame begins with a spare.</returns>
        public bool IsSpare()
        {
            if (IsStrike()) return false;
            return Scores.ElementAtOrDefault(0) + Scores.ElementAtOrDefault(1) == 10;
        }

        /// <summary>
        /// Indicates whether or not any rolls are remaining for this frame.
        /// </summary>
        public bool FrameIsComplete => Scores.Count >= 2 || Value == 10;

        /// <summary>
        /// Indicates whether or not this is the last frame in a bowling game.
        /// </summary>
        public bool IsFinalFrame { get; protected set; } = false;

        /// <summary>
        /// Verbose string describing the contents of this Frame. Useful for debug outputs.
        /// </summary>
        /// <returns>string describing the contents of this Frame.</returns>
        public override string ToString()
        {
            return $"Roll values: {string.Join(", ", Scores)} | Frame Value: {Value} | Frame Running Value: {OverallScore}";
        }

        private readonly Frame? previousFrame;

        private List<int> Bonuses { get; set; } = new List<int>();

        private bool ThirdRollNeededForLastFrame => IsFinalFrame && IsStrike() || IsSpare() && Scores.Count <= 2;

        private bool NeedsBonusPoints()
        {
            if (!IsSpare() && !IsStrike()) return false;
            if (IsSpare() && Bonuses.Count >= 1) return false;
            if (IsStrike() && Bonuses.Count >= 2) return false;
            return true;
        }
    }
}
