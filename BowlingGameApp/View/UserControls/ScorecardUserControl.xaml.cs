using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;
using Frame = BowlingGameApp.Model.Frame;

namespace BowlingGameApp.View.UserControls
{
    public partial class ScorecardUserControl : UserControl
    {
        public ScorecardUserControl()
        {
            InitializeComponent();
            Game = BowlingGameInstance.GameInstance;
            RollSparesGame();
        }

        protected BowlingGame Game { get; }

        public List<Frame> Frames
        {
            get => Game.Frames;
        }

        public List<FrameViewModel> FrameViewModels
        {
            get
            {
                List<FrameViewModel> frameViewModels = new();
                foreach (var frame in Frames)
                {
                    frameViewModels.Add(new FrameViewModel(frame));
                }
                return frameViewModels;
            }
        }

        private void RollSparesGame()
        {
            for (int roll = 0; roll < 21; roll++)
            {
                Game.AddRoll(5);
            }
        }
    }
}
