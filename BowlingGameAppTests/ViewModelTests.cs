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
        #endregion

        private void RollMany(int pointsPerRoll, int numberOfRolls)
        {
            for (int roll = 0; roll < numberOfRolls; roll++)
            {
                ViewModel.AddRoll($"{pointsPerRoll}");
            }
        }
    }
}
