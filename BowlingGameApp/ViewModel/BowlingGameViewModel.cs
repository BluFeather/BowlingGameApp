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
        
        public void AddRoll(string roll)
        {
            if (int.TryParse(roll, out var score))
            {
                GameInstance.AddRoll(score);
            }
            
            if (string.Compare(roll, "/") == 0)
            {
                var remainingPins = GameInstance.RemainingPinsThisFrame;
                GameInstance.AddRoll(remainingPins);
            }

            if (string.Compare(roll, "X", true) == 0)
            {
                GameInstance.AddRoll(10);
            }
        }

        public void ResetGame()
        {
            GameInstance.ResetGame();
        }
    }
}
