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
        
        public void AddRoll(int roll)
        {
            GameInstance.AddRoll(roll);
        }

        public void ResetGame()
        {
            GameInstance.ResetGame();
        }
    }
}
