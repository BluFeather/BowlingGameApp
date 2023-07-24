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

        public string RollOne
        {
            get
            {
                return GetRollForFrame(0);
            }
        }

        public string RollTwo
        {
            get
            {
                return GetRollForFrame(1);
            }
        }

        public string RollThree
        {
            get
            {
                return GetRollForFrame(2);
            }
        }

        public string RunningScore
        {
            get
            {
                return Frame.FrameIsComplete && !Frame.NeedsBonusPoints ? $"{Frame.OverallScore}" : string.Empty;
            }
        }

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
