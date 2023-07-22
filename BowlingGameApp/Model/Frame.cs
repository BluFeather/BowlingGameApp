using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BowlingGameApp.Model
{
    /// <summary>
    /// Represents a single turn in bowling.
    /// </summary>
    public class Frame
    {
        public Frame() : this(null)
        {

        }

        public Frame(Frame? previousFrame)
        {
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
        /// Overall points awarded by this frame in the game.
        /// </summary>
        public int RunningValue
        {
            get
            {
                return previousFrame != null ? Value + previousFrame.RunningValue : Value;
            }
        }

        /// <summary>
        /// Adds the value of a roll to this frame.
        /// </summary>
        /// <param name="rollValue">Points to be added for the roll.</param>
        public void AddRoll(int rollValue)
        {
            Scores.Add(rollValue);
        }

        /// <summary>
        /// Adds rollValue to this frame's score if it needs bonus points for a spare or strike.
        /// </summary>
        /// <param name="rollValue">bonus points to be added to this frame's value.</param>
        public void AddBonusPoints(int rollValue)
        {
            if (!NeedsBonusPoints()) return;
            Bonuses.Add(rollValue);
        }

        /// <summary>
        /// Verbose string describing the contents of this Frame. Useful for debug outputs.
        /// </summary>
        /// <returns>string describing the contents of this Frame.</returns>
        public override string ToString()
        {
            return $"Roll values: {string.Join(", ", Scores)} | Frame Value: {Value} | Frame Running Value: {RunningValue}";
        }

        private readonly Frame? previousFrame;

        private List<int> Bonuses { get; set; } = new List<int>();

        private bool IsStrike()
        {
            return Scores.ElementAtOrDefault(0) == 10;
        }

        private bool IsSpare()
        {
            if (IsStrike()) return false;
            return Scores.ElementAtOrDefault(0) + Scores.ElementAtOrDefault(1) == 10;
        }

        private bool NeedsBonusPoints()
        {
            if (!IsSpare() && !IsStrike()) return false;
            if (IsSpare() && Bonuses.Count >= 1) return false;
            if (IsStrike() && Bonuses.Count >= 2) return false;
            return true;
        }
    }
}
