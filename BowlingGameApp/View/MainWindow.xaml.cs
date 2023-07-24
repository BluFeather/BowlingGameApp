using BowlingGameApp.Model;
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
            RollButtons.ScoreReceived += OnScoreReceived;
            Game = BowlingGameInstance.GameInstance;
        }

        private BowlingGame Game { get; }

        private void OnScoreReceived(object? sender, int value)
        {
            Game.AddRoll(value);
            UpdateScorecardRolls();
            UpdateScorecardRunningValues();
        }

        private void ResetGame_OnClick(object sender, RoutedEventArgs e)
        {
            Game.NewGame();
            UpdateScorecardRolls();
            UpdateScorecardRunningValues();
        }

        private void UpdateScorecardRolls()
        {
            List<Frame> frames = Game.Frames;
            List<string> scorecardEntries = new();
            for (int frame = 0; frame < 10; frame++)
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

        private void UpdateScorecardRunningValues()
        {
            List<Frame> frames = Game.Frames;
            List<string> runningValuesList = new();
            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                Frame frame = frames[frameIndex];
                runningValuesList.Add(frame.RunningTotalIsFinal ? $"{frame.OverallScore}" : string.Empty);
            }
            Scorecard.SetRunningValues(runningValuesList);
        }
    }
}
