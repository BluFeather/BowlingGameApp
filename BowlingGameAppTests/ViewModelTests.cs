using BowlingGameApp.ViewModel;

namespace BowlingGameAppTests
{
    public class ViewModelTests
    {
        public ViewModelTests()
        {
            ViewModel = new BowlingGameViewModel();
        }

        public BowlingGameViewModel ViewModel { get; }

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
            for (var roll = 0; roll < 20; roll++)
            {
                ViewModel.AddRoll(1);
            }

            foreach (var frame in ViewModel.Frames)
            {
                Assert.Equal(2, frame.Scores.Count); // Exactly 2 Rolls in each frame.
                foreach (var score in frame.Scores)
                {
                    Assert.Equal(1, score); // Each Roll was 1 Point.
                }
            }
        }
    }
}
