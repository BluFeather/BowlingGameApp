using BowlingGameApp.ViewModel;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class FrameViewModelTests
    {
        public FrameViewModelTests(ITestOutputHelper output)
        {
            Output = output;
            Frame = new FrameViewModel();
        }

        public ITestOutputHelper Output { get; }

        public FrameViewModel Frame { get; }
    }
}
