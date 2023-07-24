using BowlingGameApp.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            UpdateControls();
        }

        private BowlingGame Game { get; }

        private void OnScoreReceived(object? sender, int value)
        {
            Game.AddRoll(value);
            UpdateControls();
        }

        private void ResetGame_OnClick(object sender, RoutedEventArgs e)
        {
            Game.NewGame();
            UpdateControls();
        }

        private void UpdateControls()
        {
            UpdateScorecardRolls();
            UpdateScorecardRunningValues();
            UpdateValidInputs();
        }

        private void UpdateScorecardRolls()
        {
            List<Frame> frames = Game.Frames;
            List<string> scorecardEntries = new();
            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                Frame frame = frames[frameIndex];

                if (frame.IsStrike())
                {
                    scorecardEntries.Add("X");
                }
                else
                {
                    scorecardEntries.Add(frame.Scores.Count >= 1 ? $"{frame.Scores[0]}" : string.Empty);
                }

                if (frame.IsSpare())
                {
                    scorecardEntries.Add("/");
                }
                else
                {
                    scorecardEntries.Add(frame.Scores.Count >= 2 ? $"{frame.Scores[1]}" : string.Empty);
                }
                
                if (frame.IsFinalFrame)
                {
                    Debug.WriteLine(frame);
                    // Roll 3 is a spare.
                    if (frame.IsStrike() &&
                        frame.Scores.ElementAtOrDefault(1) != 10 &&
                        frame.Scores.ElementAtOrDefault(1) + frame.Scores.ElementAtOrDefault(2) == 10)
                    {
                        scorecardEntries.Add("/");
                    }

                    // Roll 3 is a strike.
                    if (frame.Scores.ElementAtOrDefault(2) == 10 &&
                        (frame.IsSpare() ||
                        frame.Scores.ElementAtOrDefault(0) + frame.Scores.ElementAtOrDefault(1) == 20))
                    {
                        scorecardEntries.Add("X");
                    }

                    scorecardEntries.Add(frame.Scores.Count >= 3 ? $"{frame.Scores[2]}" : string.Empty);
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

        private void UpdateValidInputs()
        {
            if (Game.IsComplete)
            {
                RollButtons.DisableButtons();
                return;
            }
            RollButtons.SetMaxEnabledButton(Game.RemainingPins);
        }
    }
}
