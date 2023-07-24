using BowlingGameApp.Model;
using System.Collections.Generic;

namespace BowlingGameApp.ViewModel
{
    public class BowlingGameViewModel
    {
        public BowlingGameViewModel()
        {
            GameInstance = BowlingGameInstance.GameInstance;
        }

        private BowlingGame GameInstance { get; }

        /// <summary>
        /// List of Frame objects composing a full Bowling Game's Scorecard.
        /// </summary>
        public List<Frame> Frames
        {
            get => GameInstance.Frames;
        }

        /// <summary>
        /// Current Frame in play.
        /// </summary>
        public int CurrentFrameIndex
        {
            get => GameInstance.FrameIndex;
        }

        /// <summary>
        /// Converts a string to a value the Bowling Game can use.
        /// Adds the result of a roll to the game's score.
        /// </summary>
        /// <param name="roll">Number of pins knocked down. "X" converts to a roll of 10 points. "/" converts to remaining pins.</param>
        /// <returns>bool indicating whether or not the roll was considered valid and added to the current frame.</returns>
        public bool AddRoll(string roll)
        {
            if (int.TryParse(roll, out var score))
            {
                return GameInstance.AddRoll(score);
            }
            
            if (string.Compare(roll, "/") == 0)
            {
                if (GameInstance.CurrentRoll == 0) return false;

                var remainingPins = GameInstance.RemainingPins;
                return GameInstance.AddRoll(remainingPins);
            }

            if (string.Compare(roll, "X", true) == 0)
            {
                return GameInstance.AddRoll(10);
            }

            return false;
        }

        /// <summary>
        /// Readies this game for a new match.
        /// </summary>
        public void ResetGame()
        {
            GameInstance.NewGame();
        }
    }
}
