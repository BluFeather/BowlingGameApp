using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace BowlingGameApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game = BowlingGameInstance.GameInstance;
        }

        public BowlingGame Game { get; }

        public List<FrameViewModel> Frames
        {
            get
            {
                List<FrameViewModel> frames = new List<FrameViewModel>();
                foreach (var frame in Game.Frames)
                {
                    frames.Add(new FrameViewModel(frame));
                }
                return frames;
            }
        }
    }
}
