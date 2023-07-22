using BowlingGameApp.Model;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class BowlingGameTests
    {
        public ITestOutputHelper output { get; private set; }

        private readonly BowlingGame game;

        public BowlingGameTests(ITestOutputHelper output)
        {
            this.output = output;
            game = new BowlingGame();
        }

        [Fact]
        public void ZeroPoints_IfGutterGame()
        {
            RollMany(0, 20);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void TwentyPoints_IfOnesGame()
        {
            RollMany(1, 20);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void AddSpareBonus_IfSpareInGame()
        {
            RollSpare();
            game.Roll(3);
            RollMany(0, 17);

            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void AddStrikeBonus_IfStrikeInGame()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(0, 16);

            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void ThreeHundredPoints_IfPerfectGame()
        {
            RollMany(10, 12);

            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void OneHundredFourtyNinePoints_IfExampleGame()
        {
            List<int> Rolls = new List<int>() { 8, 2, 5, 4, 9, 0, 10, 10, 5, 5, 5, 3, 6, 3, 9, 1, 9, 1, 10 };
            RollList(Rolls);

            Assert.Equal(149, game.Score());
        }

        [Fact]
        public void CanGetFramesList()
        {
            List<Frame> frames = game.GetFrames();
            Assert.Equal(10, frames.Count);
        }

        [Fact]
        public void ZeroPointsEachFrame_IfGutterGame()
        {
            List<Frame> frames = game.GetFrames();
            foreach (var frame in frames)
            {
                Assert.Equal(0, frame.Score);
            }
        }

        private void RollMany(int pins, int rolls)
        {
            for (var roll = 0; roll < rolls; roll++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollList(List<int> Rolls)
        {
            foreach (var roll in Rolls)
            {
                game.Roll(roll);
            }
        }
    }
}