using BowlingGameApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Animation;

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

        public int CurrentFrameIndex => GameInstance.FrameIndex;

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

        public string GetRollForFrame(int frame, int rollNumber)
        {
            if (Frames[frame].Scores.Count - 1 < rollNumber)
            {
                return string.Empty;
            }
            return $"{Frames[frame].Scores.ElementAtOrDefault(0)}";
        }
    }
}
