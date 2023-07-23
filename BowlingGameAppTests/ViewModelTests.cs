using BowlingGameApp.ViewModel;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class ViewModelTests
    {
        [Fact]
        public void ViewModelContainsTenFrames()
        {
            BowlingGameViewModel bowlingGameVM = new BowlingGameViewModel();
            Assert.Equal(10, bowlingGameVM.Frames.Count);
        }
    }
}
