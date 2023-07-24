using BowlingGameApp.Model;
using System;
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

        public List<Frame> Frames
        {
            get => GameInstance.Frames;
        }

        private int CurrentRoll => GameInstance.CurrentRoll;
        
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

        public void ResetGame()
        {
            GameInstance.NewGame();
        }
    }
}
