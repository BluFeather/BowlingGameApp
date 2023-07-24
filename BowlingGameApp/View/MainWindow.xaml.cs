using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace BowlingGameApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game = BowlingGameInstance.GameInstance;
            for (int roll = 0; roll < 21; roll++)
            {
                Game.AddRoll(5);
            }
        }

        public BowlingGame Game { get; }

        public List<FrameViewModel> Frames
        {
            get
            {
                List<FrameViewModel> frames = new List<FrameViewModel>();
                foreach (var frame in Game.Frames)
                {
                    Debug.WriteLine(frame);
                    frames.Add(new FrameViewModel(frame));
                }
                return frames;
            }
        }
    }
}
