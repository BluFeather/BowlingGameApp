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

        /// <summary>
        /// Position of this frame in a scorecard. Numbering begins at 1.
        /// </summary>
        public string FrameNumber
        {
            get
            {
                return $"{Frame.FrameNumber}";
            }
        }

        /// <summary>
        /// Value of this frame's first roll. String is empty if there is no roll.
        /// </summary>
        public string RollOne
        {
            get
            {
                return GetRollForFrame(0);
            }
        }

        /// <summary>
        /// Value of this frame's second roll. String is empty if there is no roll.
        /// </summary>
        public string RollTwo
        {
            get
            {
                return GetRollForFrame(1);
            }
        }

        /// <summary>
        /// Value of this frame's third roll. String is empty if there is no roll. Only used in the final frame.
        /// </summary>
        public string RollThree
        {
            get
            {
                return GetRollForFrame(2);
            }
        }

        /// <summary>
        /// Total score by the conclusion of this frame.
        /// Empty until there are no rolls left for this frame and the frame's bonuses have been awarded.
        /// </summary>
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
