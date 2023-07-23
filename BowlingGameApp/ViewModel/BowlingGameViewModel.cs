using BowlingGameApp.Model;
using System.Collections.Generic;

namespace BowlingGameApp.ViewModel
{
    public class BowlingGameViewModel
    {
        public List<Frame> Frames
        {
            get => BowlingGameInstance.GameInstance.Frames;
        }
    }
}
