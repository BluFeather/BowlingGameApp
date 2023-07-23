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

        public BowlingGame GameInstance { get; }

        public List<Frame> Frames
        {
            get => GameInstance.Frames;
        }
        
        public void AddRoll(int roll)
        {
            GameInstance.AddRoll(roll);
        }
    }
}
