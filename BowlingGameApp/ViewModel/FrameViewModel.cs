using BowlingGameApp.Model;
using System.Linq;

namespace BowlingGameApp.ViewModel
{
    public class FrameViewModel
    {
        public FrameViewModel(Frame frame)
        {
            Frame = frame;
        }

        protected Frame Frame { get; }

        public string RollOne => GetRollForFrame(0);

        public string RollTwo => GetRollForFrame(1);

        public string RollThree => GetRollForFrame(2);

        public string RunningScore => $"{Frame.OverallScore}";

        private string GetRollForFrame(int rollNumber)
        {
            if (Frame.Scores.Count - 1 < rollNumber)
            {
                return string.Empty;
            }
            return $"{Frame.Scores.ElementAtOrDefault(0)}";
        }
    }
}
