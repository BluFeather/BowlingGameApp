using BowlingGameApp.Model;
using System.Collections.Generic;
using System.Windows;

namespace BowlingGameApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RollButtons.ScoreReceived += OnScoreReceived;
            Game = BowlingGameInstance.GameInstance;
        }

        private BowlingGame Game { get; }

        private void OnScoreReceived(object? sender, int value)
        {
            Game.AddRoll(value);
        }

        private void UpdateScorecard()
        {
            List<Frame> frames = Game.Frames;
            for (int i = 0; i < frames.Count; i++)
            {
                List<int> scorecardEntries = new List<int>();

            }
        }
    }
}
