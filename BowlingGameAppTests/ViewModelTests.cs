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
    }
}
