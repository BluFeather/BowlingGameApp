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
        }

        public ITestOutputHelper Output { get; }

        [Fact]
        public void UnplayedRollReturnsEmptyString()
        {
            BowlingGame Game = new BowlingGame();
            var Frame = new FrameViewModel(Game.Frames[1]);

            Assert.Equal(string.Empty, Frame.RollOne);
            Assert.Equal(string.Empty, Frame.RollTwo);
            Assert.Equal(string.Empty, Frame.RollThree);
        }

        [Fact]
        public void GutterballReturnsZeroString()
        {
            BowlingGame Game = new BowlingGame();
            var Frame = new FrameViewModel(Game.Frames[0]);
            Game.AddRoll(0);

            Assert.Equal("0", Frame.RollOne);
        }

        [Fact]
        public void RunningScoreIsGiven_IfCompletedFrame()
        {
            var game = NewGame();
            RollMany(game, 5, 5);
            var Frame = NewFrame(game.Frames[1]);

            Assert.Equal("30", $"{Frame.RunningScore}");
        }

        [Fact]
        public void RunningScoreIsBlankString_IfUnfinishedFrame()
        {
            var game = NewGame();
            RollMany(game, 5, 5);
            var Frame = NewFrame(game.Frames[2]);

            Assert.Equal(string.Empty, $"{Frame.RunningScore}");
        }

        [Fact]
        public void RunningScoreIsBlankString_IfMissingBonuses()
        {
            var game = NewGame();
            RollMany(game, 10, 3);
            var Frame = NewFrame(game.Frames[2]);

            Assert.Equal(string.Empty, $"{Frame.RunningScore}");
        }

        private BowlingGame NewGame() => new BowlingGame();

        private FrameViewModel NewFrame(Frame frame) => new FrameViewModel(frame);

        private void Roll(BowlingGame game, int numberOfPins)
        {
            game.AddRoll(numberOfPins);
        }

        private void RollMany(BowlingGame game, int numberOfPins, int numberOfRolls)
        {
            for (int roll = 0; roll < numberOfRolls; roll++)
            {
                Roll(game, numberOfPins);
            }
        }
    }
}
