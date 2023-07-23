using BowlingGameApp.Model;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class BowlingGameTestsTwo
    {
        public BowlingGameTestsTwo(ITestOutputHelper output)
        {
            Output = output;
            Game = new BowlingGame();
        }

        public ITestOutputHelper Output { get; }

        public BowlingGame Game { get; }

        #region Expected Value Tests
        [Fact]
        public void ExpectedValuesIfGutterGame()
        {
            int valueOfRolls = 0;
            int numberOfRolls = 20;

            RollMany(valueOfRolls, numberOfRolls);
            PassIfExpectedRollCount(numberOfRolls);
            
            var frames = GetFrames();
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");
                Assert.Equal(2, frames[frame].Scores.Count);
                for (int roll = 0; roll < 2; roll++)
                {
                    Assert.Equal(valueOfRolls, frames[frame].Scores[roll]);
                }
            }
        }

        [Fact]
        public void ExpectedValuesIfOnesGame()
        {
            int valueOfRolls = 1;
            int numberOfRolls = 20;

            RollMany(valueOfRolls, numberOfRolls);
            PassIfExpectedRollCount(numberOfRolls);

            var frames = GetFrames();
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");
                Assert.Equal(2, frames[frame].Scores.Count);
                for (int roll = 0; roll < 2; roll++)
                {
                    Assert.Equal(valueOfRolls, frames[frame].Scores[roll]);
                }
            }
        }

        private void PassIfExpectedRollCount(int expectedRollCount)
        {
            Assert.Equal(expectedRollCount, GetRolls().Count);
        }
        #endregion

        private void Roll(int pointsEachRoll)
        {
            Game.AddRoll(pointsEachRoll);
        }

        private void RollMany(int pointsEachRoll, int numberOfRolls)
        {
            for (int roll = 0; roll < numberOfRolls; roll++)
            {
                Roll(pointsEachRoll);
            }
        }

        private List<int> GetRolls() => Game.PlayedRolls;

        private List<Frame> GetFrames() => Game.Frames;
    }
}
