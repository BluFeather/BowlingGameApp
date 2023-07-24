using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class ViewModelTests
    {
        public ViewModelTests(ITestOutputHelper output)
        {
            Output = output;
            ViewModel = new BowlingGameViewModel();
        }

        public ITestOutputHelper Output { get; }

        private readonly BowlingGameViewModel ViewModel;

        #region Input Validation Tests
        [Fact]
        public void CanRollValuesGreaterOrEqualToZero()
        {
            for (int value = -5; value <= 10; value++)
            {
                string valueString = $"{value}";

                ViewModel.ResetGame();
                bool result = ViewModel.AddRoll(valueString);
                Output.WriteLine($"\"{valueString}\" returned {result}");
                
                if (value >= 0)
                {
                    Assert.True(result);
                }
                else
                {
                    Assert.False(result);
                }
            }
        }

        [Fact]
        public void CanRollValuesLessThanOrEqualToTen()
        {
            for (int value = 0; value <= 15; value++)
            {
                string valueString = $"{value}";

                ViewModel.ResetGame();
                bool result = ViewModel.AddRoll(valueString);
                Output.WriteLine($"\"{valueString}\" returned {result}");

                if (value <= 10)
                {
                    Assert.True(result);
                }
                else
                {
                    Assert.False(result);
                }
            }
        }

        [Fact]
        public void EnteringXResultsInStrike_CaseInsensitive()
        {
            ViewModel.ResetGame();
            Assert.True(ViewModel.AddRoll("X"));
            Assert.True(ViewModel.AddRoll("x"));

            Assert.True(ViewModel.Frames[0].Scores.Count == 1);
            Assert.True(ViewModel.Frames[0].Scores[0] == 10);
            Assert.True(ViewModel.Frames[1].Scores.Count == 1);
            Assert.True(ViewModel.Frames[1].Scores[0] == 10);
            Assert.True(ViewModel.Frames[2].Scores.Count == 0);
        }

        [Fact]
        public void EnteringSlashAsFirstRollInAnyFrameIsRejected()
        {
            ViewModel.ResetGame();
            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                ViewModel.AddRoll("/");
                Assert.Empty(frames[frame].Scores);

                ViewModel.AddRoll("1");
                ViewModel.AddRoll("1");
                Assert.Equal(2, frames[frame].Scores.Count);
                Assert.True(frames[frame].Scores[0] == 1);
                Assert.True(frames[frame].Scores[1] == 1);
            }
        }

        [Fact]
        public void EnteringSlashAsSecondRollInAnyFrameResultsInSpare()
        {
            ViewModel.ResetGame();
            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                ViewModel.AddRoll($"{frame}");
                ViewModel.AddRoll("/");
                Output.WriteLine($"{frames[frame]}");
                Assert.True(ViewModel.Frames[frame].IsSpare());
            }
        }
        #endregion

        #region Expected Value Tests
        [Fact]
        public void ExpectedValuesIfGutterGame()
        {
            int rollValues = 0;

            ViewModel.ResetGame();
            RollMany(rollValues, 50);

            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                Frame currentFrame = frames[frame];

                Output.WriteLine($"{currentFrame}");
                Assert.True(currentFrame.Scores.Count == 2);
                Assert.Equal(rollValues, currentFrame.Scores[0]);
                Assert.Equal(rollValues, currentFrame.Scores[1]);
            }
        }

        [Fact]
        public void ExpectedValuesIfSinglesGame()
        {
            int rollValues = 1;

            ViewModel.ResetGame();
            RollMany(rollValues, 50);

            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                Frame currentFrame = frames[frame];

                Output.WriteLine($"{currentFrame}");
                Assert.True(currentFrame.Scores.Count == 2);
                Assert.Equal(rollValues, currentFrame.Scores[0]);
                Assert.Equal(rollValues, currentFrame.Scores[1]);
            }
        }

        [Fact]
        public void ExpectedValuesIfSparesGame()
        {
            int rollValues = 5;

            ViewModel.ResetGame();
            RollMany(rollValues, 50);

            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                Frame currentFrame = frames[frame];
                Output.WriteLine($"{currentFrame}");
                if (frame == 9)
                {
                    Assert.True(currentFrame.Scores.Count == 3);
                    Assert.Equal(rollValues, currentFrame.Scores[2]);
                }
                else
                {
                    Assert.True(currentFrame.Scores.Count == 2);
                }

                Assert.Equal(rollValues, currentFrame.Scores[0]);
                Assert.Equal(rollValues, currentFrame.Scores[1]);
            }
        }

        [Fact]
        public void ExpectedValuesIfPerfectGame()
        {
            int rollValues = 10;

            ViewModel.ResetGame();
            RollMany(rollValues, 50);

            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                Frame currentFrame = frames[frame];
                Output.WriteLine($"{currentFrame}");
                if (frame == 9)
                {
                    Assert.True(currentFrame.Scores.Count == 3);
                    Assert.Equal(rollValues, currentFrame.Scores[2]);
                }
                else
                {
                    Assert.True(currentFrame.Scores.Count == 1);
                }

                Assert.Equal(rollValues, currentFrame.Scores[0]);
            }
        }

        [Fact]
        public void ExpectedValuesIfExampleGame()
        {
            List<int> exampleGameList = new() { 8, 2, 5, 4, 9, 0, 10, 10, 5, 5, 5, 3, 6, 3, 9, 1, 9, 1, 10 };
            ViewModel.ResetGame();
            RollList(exampleGameList);

            var frames = ViewModel.Frames;
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");

                switch (frame)
                {
                    case 0:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(8, frames[frame].Scores[0]);
                        Assert.Equal(2, frames[frame].Scores[1]);
                        continue;
                    case 1:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(5, frames[frame].Scores[0]);
                        Assert.Equal(4, frames[frame].Scores[1]);
                        continue;
                    case 2:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(9, frames[frame].Scores[0]);
                        Assert.Equal(0, frames[frame].Scores[1]);
                        continue;
                    case 3:
                        Assert.Single(frames[frame].Scores);
                        Assert.Equal(10, frames[frame].Scores[0]);
                        continue;
                    case 4:
                        Assert.Single(frames[frame].Scores);
                        Assert.Equal(10, frames[frame].Scores[0]);
                        continue;
                    case 5:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(5, frames[frame].Scores[0]);
                        Assert.Equal(5, frames[frame].Scores[1]);
                        continue;
                    case 6:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(5, frames[frame].Scores[0]);
                        Assert.Equal(3, frames[frame].Scores[1]);
                        continue;
                    case 7:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(6, frames[frame].Scores[0]);
                        Assert.Equal(3, frames[frame].Scores[1]);
                        continue;
                    case 8:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(9, frames[frame].Scores[0]);
                        Assert.Equal(1, frames[frame].Scores[1]);
                        continue;
                    case 9:
                        Assert.Equal(3, frames[frame].Scores.Count);
                        Assert.Equal(9, frames[frame].Scores[0]);
                        Assert.Equal(1, frames[frame].Scores[1]);
                        Assert.Equal(10, frames[frame].Scores[2]);
                        continue;
                }
            }
        }
        #endregion

        #region Property and Method Tests
        [Fact]
        public void CanResetGame()
        {
            ViewModel.ResetGame();
            RollMany(5, 7);
            Output.WriteLine($"Frame 2 before reset.\n{ViewModel.Frames[2]}");
            Assert.Equal("5", $"{ViewModel.Frames[2].Scores[0]}");

            ViewModel.ResetGame();
            RollMany(2, 7);
            Output.WriteLine($"Frame 2 after reset.\n{ViewModel.Frames[2]}");
            Assert.Equal("2", $"{ViewModel.Frames[2].Scores[0]}");
        }

        [Fact]
        public void CanGetCurrentFrameIndex()
        {
            ViewModel.ResetGame();
            RollMany(5, 7);
            Assert.Equal(3, ViewModel.CurrentFrameIndex);
        }
        #endregion

        private void Roll(int pointsForRoll)
        {
            ViewModel.AddRoll($"{pointsForRoll}");
        }

        private void RollMany(int pointsPerRoll, int numberOfRolls)
        {
            for (int roll = 0; roll < numberOfRolls; roll++)
            {
                Roll(pointsPerRoll);
            }
        }

        private void RollList(List<int> rollList)
        {
            foreach (int roll in rollList)
            {
                Roll(roll);
            }
        }
    }
}
