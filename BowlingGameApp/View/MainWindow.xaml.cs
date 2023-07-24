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
            UpdateScorecard();
        }

        private void UpdateScorecard()
        {
            List<Frame> frames = Game.Frames;
            List<string> scorecardEntries = new List<string>();
            for (int frame = 0; frame < frames.Count; frame++)
            {
                scorecardEntries.Add(frames[frame].Scores.Count >= 1 ? $"{frames[frame].Scores[0]}" : string.Empty);
                scorecardEntries.Add(frames[frame].Scores.Count >= 2 ? $"{frames[frame].Scores[1]}" : string.Empty);

                if (frame == 9)
                {
                    scorecardEntries.Add(frames[frame].Scores.Count >= 3 ? $"{frames[frame].Scores[2]}" : string.Empty);
                }
            }
            Scorecard.SetRolls(scorecardEntries);
        }
    }
}
