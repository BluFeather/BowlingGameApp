using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class ViewModelTests
    {
        public ViewModelTests(ITestOutputHelper output)
        {
            ViewModel = new BowlingGameViewModel();
            this.output = output;
        }

        public BowlingGameViewModel ViewModel { get; }

        private ITestOutputHelper output;

        [Fact]
        public void ViewModelContainsTenFrames()
        {
            Assert.Equal(10, ViewModel.Frames.Count);
        }

        [Fact]
        public void ViewModelFramesAreNotNull()
        {
            foreach (var frame in ViewModel.Frames)
            {
                Assert.NotNull(frame);
            }
        }

        [Fact]
        public void FramesContainSingleRolls_IfSinglesGame()
        {
            ResetGame();
            RollMany("1", 20);

            foreach (var frame in ViewModel.Frames)
            {
                Assert.Equal(2, frame.Scores.Count); // Exactly 2 Rolls in each frame.
                foreach (var score in frame.Scores)
                {
                    Assert.Equal(1, score); // Each Roll was 1 Point.
                }
            }
        }

        [Fact]
        public void FramesContainDoubleRolls_IfDoublesGame()
        {
            ResetGame();
            RollMany("2", 20);

            foreach (var frame in ViewModel.Frames)
            {
                Assert.Equal(2, frame.Scores.Count); // Exactly 2 Rolls in each frame.
                foreach (var score in frame.Scores)
                {
                    Assert.Equal(2, score); // Each Roll was 2 Points.
                }
            }
        }

        [Fact]
        public void CanResetMidGame()
        {
            ResetGame();
            RollMany("5", 5);
            Assert.Equal(5, GetRolls().Count);

            ResetGame();
            RollMany("1", 1);
            Assert.Single(GetRolls());
        }

        [Fact]
        public void CanRollSpareUsingSlash()
        {
            ResetGame();
            Roll("4");
            Roll("/");
            Assert.Equal(4, GetFrame(0).Scores[0]);
            Assert.Equal(6, GetFrame(0).Scores[1]);
        }

        [Fact]
        public void CanRollStrikesUsingX()
        {
            ResetGame();
            Roll("X");
            Roll("x");
            Assert.Equal(10, GetFrame(0).Scores[0]);
            Assert.Equal(10, GetFrame(1).Scores[0]);
        }

        private void ResetGame()
        {
            ViewModel.ResetGame();
        }

        private void Roll(string numberOfPins)
        {
            ViewModel.AddRoll(numberOfPins);
        }

        private void RollMany(string numberOfPins, int numberOfRolls)
        {
            for (var roll = 0; roll < numberOfRolls; roll++)
            {
                Roll(numberOfPins);
            }
        }

        private Frame GetFrame(int frameNumber)
        {
            return GetFrames()[frameNumber];
        }

        private List<Frame> GetFrames()
        {
            return ViewModel.Frames;
        }

        private List<int> GetRolls()
        {
            List<int> rollList = new List<int>();
            foreach (var frame in GetFrames())
            {
                rollList.AddRange(frame.Scores);
            }
            return rollList;
        }
    }
}
