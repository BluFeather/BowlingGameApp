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
        #endregion
    }
}
