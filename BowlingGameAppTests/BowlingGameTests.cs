using BowlingGameApp.Model;

namespace BowlingGameAppTests
{
    public class BowlingGameTests
    {
        private readonly BowlingGame game;

        public BowlingGameTests()
        {
            game = new BowlingGame();
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
    }
}