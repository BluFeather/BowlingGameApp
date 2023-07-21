using BowlingGameApp.Model;

namespace BowlingGameAppTests
{
    public class BowlingGameTests
    {
        [Fact]
        public void ZeroPoints_IfGutterGame()
        {
            var game = new BowlingGame();
            for (var roll = 0; roll < 20; roll++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.Score());
        }
    }
}