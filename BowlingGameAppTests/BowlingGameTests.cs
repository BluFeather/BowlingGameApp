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

        #region Algorithm Tests
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
        #endregion

        #region Frame Object Tests
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
        #endregion

        #region Realtime Scoring Tests
        [Fact]
        public void CanGetScoreMidGame()
        {
            game.AddRoll(5);
            game.CalculateFinalScore();
        }

        [Fact]
        public void FrameTwoIsZeroPoints_IfHalfGutterGame()
        {
            RollMany(0, 10);

            output.WriteLine($"Final Score: {GetFinalScore()}");

            foreach (var frame in GetFrames())
            {
                output.WriteLine(frame?.ToString());
            }

            Frame? frameTwo = GetFrame(1);
            Assert.Equal(0, frameTwo?.RunningValue);
        }

        [Fact]
        public void FrameTwoIsFourPoints_IfHalfSinglesGame()
        {
            RollMany(1, 10);
            output.WriteLine($"Final Score: {GetFinalScore()}");

            foreach (var frame in GetFrames())
            {
                output.WriteLine(frame?.ToString());
            }

            Frame? frameTwo = GetFrame(1);
            Assert.Equal(4, frameTwo?.RunningValue);
        }

        [Fact]
        public void FrameFourIsOneHundredTwentyPoints_IfHalfPerfectGame()
        {
            RollMany(10, 6);
            output.WriteLine($"Final Score: {GetFinalScore()}");

            foreach (var frame in GetFrames())
            {
                output.WriteLine(frame?.ToString());
            }

            Frame? frameFour = GetFrame(3);
            Assert.Equal(120, frameFour?.RunningValue);
        }

        [Fact]
        public void FramesAreExpectedPoints_IfExampleGame()
        {
            RollList(exampleGameList);
            output.WriteLine($"Final Score: {GetFinalScore()}");
            
            foreach (var frame in GetFrames())
            {
                output.WriteLine(frame?.ToString());
            }

            for (int frame = 0; frame < 10; frame++)
            {
                Frame? currentFrame = GetFrame(frame);
                switch (frame)
                {
                    case 0:
                        Assert.Equal(15, currentFrame?.RunningValue);
                        continue;
                    case 1:
                        Assert.Equal(24, currentFrame?.RunningValue);
                        continue;
                    case 2:
                        Assert.Equal(33, currentFrame?.RunningValue);
                        continue;
                    case 3:
                        Assert.Equal(58, currentFrame?.RunningValue);
                        continue;
                    case 4:
                        Assert.Equal(78, currentFrame?.RunningValue);
                        continue;
                    case 5:
                        Assert.Equal(93, currentFrame?.RunningValue);
                        continue;
                    case 6:
                        Assert.Equal(101, currentFrame?.RunningValue);
                        continue;
                    case 7:
                        Assert.Equal(110, currentFrame?.RunningValue);
                        continue;
                    case 8:
                        Assert.Equal(129, currentFrame?.RunningValue);
                        continue;
                    case 9:
                        Assert.Equal(149, currentFrame?.RunningValue);
                        continue;
                    default:
                        Assert.Fail($"Frame {frame} is unexpected!");
                        continue;
                }
            }
        }
        #endregion

        #region Input Validation Tests
        [Fact]
        public void AddRollReturnsFalse_IfRollHigherThanRemainingPins()
        {
            Assert.True(Roll(6));
            Assert.False(Roll(6));
        }

        [Fact]
        public void AddRollAlwaysReturnsTrue_IfPerfectGame()
        {
            RollMany(10, 12, true);
        }
        #endregion

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

        private bool Roll(int pins)
        {
            return game.AddRoll(pins);
        }

        private void RollMany(int pins, int rolls, bool failIfAnyFalse = false)
        {
            for (var roll = 0; roll < rolls; roll++)
            {
                if (game.AddRoll(pins) == false && failIfAnyFalse)
                {
                    Assert.Fail($"roll {roll} of value {pins} was considered invalid!");
                }
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

        private Frame? GetFrame(int frameIndex)
        {
            return GetFrames().ElementAtOrDefault(frameIndex);
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
