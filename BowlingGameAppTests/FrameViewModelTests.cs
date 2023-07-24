using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class FrameViewModelTests
    {
        public FrameViewModelTests(ITestOutputHelper output)
        {
            Output = output;
            BowlingGame Game = new BowlingGame();
            Frame = new FrameViewModel(Game.Frames[1]);
        }

        public ITestOutputHelper Output { get; }

        public FrameViewModel Frame { get; }

        [Fact]
        public void UnplayedRollReturnsEmptyString()
        {
            Assert.Equal(string.Empty, Frame.RollOne);
            Assert.Equal(string.Empty, Frame.RollTwo);
            Assert.Equal(string.Empty, Frame.RollThree);
        }
    }
}
