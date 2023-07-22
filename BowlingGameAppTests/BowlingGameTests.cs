using BowlingGameApp.Model;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class BowlingGameTests
    {
        public ITestOutputHelper output { get; private set; }

        private readonly BowlingGame game;

        private readonly List<int> exampleGameList = new List<int>() { 8, 2, 5, 4, 9, 0, 10, 10, 5, 5, 5, 3, 6, 3, 9, 1, 9, 1, 10 };

        public BowlingGameTests(ITestOutputHelper output)
        {
            this.output = output;
            game = new BowlingGame();
        }

        [Fact]
        public void ZeroPoints_IfGutterGame()
        {
            RollMany(0, 20);
            Assert.Equal(0, game.CalculateFinalScore());
        }

        [Fact]
        public void TwentyPoints_IfOnesGame()
        {
            RollMany(1, 20);
            Assert.Equal(20, game.CalculateFinalScore());
        }

        [Fact]
        public void AddSpareBonus_IfSpareInGame()
        {
            RollSpare();
            game.AddRoll(3);
            RollMany(0, 17);

            Assert.Equal(16, game.CalculateFinalScore());
        }

        [Fact]
        public void AddStrikeBonus_IfStrikeInGame()
        {
            RollStrike();
            game.AddRoll(3);
            game.AddRoll(4);
            RollMany(0, 16);
            Assert.Equal(24, game.CalculateFinalScore());
        }

        [Fact]
        public void ThreeHundredPoints_IfPerfectGame()
        {
            RollMany(10, 12);
            Assert.Equal(300, game.CalculateFinalScore());
        }

        [Fact]
        public void OneHundredFourtyNinePoints_IfExampleGame()
        {
            RollList(exampleGameList);
            Assert.Equal(149, game.CalculateFinalScore());
        }

        [Fact]
        public void CanGetFramesList()
        {
            RollMany(0, 20);
            Assert.Equal(10, GetFrames().Count);
        }

        [Fact]
        public void ZeroRolls_ZeroFrameScore_ZeroFinalScore_IfGutterGame()
        {
            int ValuePerRoll = 0;
            int ValuePerFrame = 0;
            int ExpectedFinalScore = 0;

            TestConsistentGame(ValuePerRoll, ValuePerFrame, ExpectedFinalScore);
        }

        [Fact]
        public void SingleRolls_TwoFrameScore_TwentyFinalScore_IfSinglesGame()
        {
            int ValuePerRoll = 1;
            int ValuePerFrame = 2;
            int ExpectedFinalScore = 20;

            TestConsistentGame(ValuePerRoll, ValuePerFrame, ExpectedFinalScore);
        }

        [Fact]
        public void TenRolls_ThirtyFrameScore_ThreeHundredScore_IfPerfectGame()
        {
            int ValuePerRoll = 10;
            int ValuePerFrame = 30;
            int ExpectedFinalScore = 300;

            TestConsistentGame(ValuePerRoll, ValuePerFrame, ExpectedFinalScore);
        }

        [Fact]
        public void ExpectedRolls_ExpectedFrameScore_OneHundredFourtyNineScore_IfExampleGame()
        {
            int ExpectedFinalScore = 149;

            RollList(exampleGameList);
            var frames = GetFrames();
            for (int frame = 0; frame < frames.Count; frame++)
            {
                switch (frame)
                {
                    case 0:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(8, frames[frame].Scores[0]);
                        Assert.Equal(2, frames[frame].Scores[1]);
                        continue;
                    case 1:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(5, frames[frame].Scores[0]);
                        Assert.Equal(4, frames[frame].Scores[1]);
                        continue;
                    case 2:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(9, frames[frame].Scores[0]);
                        Assert.Equal(0, frames[frame].Scores[1]);
                        continue;
                    case 3:
                        Assert.Single(frames[frame].Scores);
                        Assert.Equal(10, frames[frame].Scores[0]);
                        continue;
                    case 4:
                        Assert.Single(frames[frame].Scores);
                        Assert.Equal(10, frames[frame].Scores[0]);
                        continue;
                    case 5:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(5, frames[frame].Scores[0]);
                        Assert.Equal(5, frames[frame].Scores[1]);
                        continue;
                    case 6:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(5, frames[frame].Scores[0]);
                        Assert.Equal(3, frames[frame].Scores[1]);
                        continue;
                    case 7:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(6, frames[frame].Scores[0]);
                        Assert.Equal(3, frames[frame].Scores[1]);
                        continue;
                    case 8:
                        Assert.Equal(2, frames[frame].Scores.Count);
                        Assert.Equal(9, frames[frame].Scores[0]);
                        Assert.Equal(1, frames[frame].Scores[1]);
                        continue;
                    case 9:
                        Assert.Equal(3, frames[frame].Scores.Count);
                        Assert.Equal(9, frames[frame].Scores[0]);
                        Assert.Equal(1, frames[frame].Scores[1]);
                        Assert.Equal(10, frames[frame].Scores[2]);
                        continue;
                    default:
                        Assert.Fail($"Frame {frame} is unexpected!");
                        continue;
                }
            }
            Assert.Equal(ExpectedFinalScore, GetFinalScore());
        }

        private void TestConsistentGame(int ValuePerRoll, int ValuePerFrame, int ExpectedFinalScore)
        {
            RollMany(ValuePerRoll, 20);
            foreach (var frame in GetFrames())
            {
                foreach (var roll in frame.Scores)
                {
                    Assert.Equal(ValuePerRoll, roll);
                }
                Assert.Equal(ValuePerFrame, frame.Value);
            }
            Assert.Equal(ExpectedFinalScore, GetFinalScore());
        }

        private void RollMany(int pins, int rolls)
        {
            for (var roll = 0; roll < rolls; roll++)
            {
                game.AddRoll(pins);
            }
        }

        private void RollSpare()
        {
            game.AddRoll(5);
            game.AddRoll(5);
        }

        private void RollStrike()
        {
            game.AddRoll(10);
        }

        private void RollList(List<int> Rolls)
        {
            foreach (var roll in Rolls)
            {
                game.AddRoll(roll);
            }
        }

        private List<Frame> GetFrames()
        {
            return game.Frames;
        }

        private List<int> GetRolls()
        {
            return game.Rolls;
        }

        private int GetFinalScore()
        {
            return game.CalculateFinalScore();
        }
    }
}
