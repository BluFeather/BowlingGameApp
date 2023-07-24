using BowlingGameApp.ViewModel;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class ViewModelTestsTwo
    {
        public ViewModelTestsTwo(ITestOutputHelper output)
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
        #endregion
    }
}
