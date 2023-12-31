﻿using BowlingGameApp.Model;
using Xunit.Abstractions;

namespace BowlingGameAppTests
{
    public class BowlingGameTests
    {
        public BowlingGameTests(ITestOutputHelper output)
        {
            Output = output;
            Game = new BowlingGame();
        }

        public ITestOutputHelper Output { get; }

        public BowlingGame Game { get; }

        #region Expected Value Tests
        [Fact]
        public void ExpectedValuesIfGutterGame()
        {
            int valueOfRolls = 0;
            int numberOfRolls = 20;
            int expectedFinalScore = 0;

            RollMany(valueOfRolls, numberOfRolls);
            PassIfExpectedRollCount(numberOfRolls);
            
            var frames = GetFrames();
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");
                Assert.Equal(2, frames[frame].Scores.Count);
                for (int roll = 0; roll < 2; roll++)
                {
                    Assert.Equal(valueOfRolls, frames[frame].Scores[roll]);
                }
            }

            Assert.Equal(expectedFinalScore, GetScore());
        }

        [Fact]
        public void ExpectedValuesIfOnesGame()
        {
            int valueOfRolls = 1;
            int numberOfRolls = 20;
            int expectedFinalScore = 20;

            RollMany(valueOfRolls, numberOfRolls);
            PassIfExpectedRollCount(numberOfRolls);

            var frames = GetFrames();
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");
                Assert.Equal(2, frames[frame].Scores.Count);
                for (int roll = 0; roll < 2; roll++)
                {
                    Assert.Equal(valueOfRolls, frames[frame].Scores[roll]);
                }
            }

            Assert.Equal(expectedFinalScore, GetScore());
        }

        [Fact]
        public void ExpectedValuesIfSparesGame()
        {
            int valueOfRolls = 5;
            int numberOfRolls = 21;
            int expectedFinalScore = 150;

            RollMany(valueOfRolls, numberOfRolls);
            PassIfExpectedRollCount(numberOfRolls);

            var frames = GetFrames();
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");

                int expectedRollsThisFrame = frame != 9 ? 2 : 3;
                Assert.Equal(expectedRollsThisFrame, frames[frame].Scores.Count);
                for (int roll = 0; roll < frames[frame].Scores.Count; roll++)
                {
                    Assert.Equal(valueOfRolls, frames[frame].Scores[roll]);
                }
            }

            Assert.Equal(expectedFinalScore, GetScore());
        }

        [Fact]
        public void ExpectedValuesIfPerfectGame()
        {
            int valueOfRolls = 10;
            int numberOfRolls = 12;
            int expectedFinalScore = 300;

            RollMany(valueOfRolls, numberOfRolls);
            PassIfExpectedRollCount(numberOfRolls);

            var frames = GetFrames();
            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");

                int expectedRollsThisFrame = frame != 9 ? 1 : 3;
                Assert.Equal(expectedRollsThisFrame, frames[frame].Scores.Count);
                for (int roll = 0; roll < frames[frame].Scores.Count; roll++)
                {
                    Assert.Equal(valueOfRolls, frames[frame].Scores[roll]);
                }
            }

            Assert.Equal(expectedFinalScore, GetScore());
        }

        [Fact]
        public void ExpectedValuesIfExampleGame()
        {
            List<int> exampleGameList = new() { 8, 2, 5, 4, 9, 0, 10, 10, 5, 5, 5, 3, 6, 3, 9, 1, 9, 1, 10 };
            int expectedFinalScore = 149;

            RollList(exampleGameList);
            PassIfExpectedRollCount(exampleGameList.Count);

            var frames = GetFrames();

            for (int frame = 0; frame < 10; frame++)
            {
                Output.WriteLine($"{frames[frame]}");

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
                }
            }

            Assert.Equal(expectedFinalScore, GetScore());
        }
        #endregion

        #region Input Validation Tests
        [Fact]
        public void CanOnlyRoll20Times_IfNo10thFrameBonus()
        {
            RollMany(0, 25);
            Assert.Equal(20, GetRolls().Count);
        }

        [Fact]
        public void CanOnlyRoll21Times_If10thFrameBonus()
        {
            RollMany(5, 21);
            Assert.Equal(21, GetRolls().Count);
        }

        [Fact]
        public void CanOnlyRoll12Times_IfPerfectGame()
        {
            RollMany(10, 20);
            Assert.Equal(12, GetRolls().Count);
        }

        [Fact]
        public void CanOnlyRollPinsGreaterOrEqualToZero()
        {
            for (int rollValue = 10;  rollValue > -100; rollValue--)
            {
                Roll(rollValue);
            }

            foreach (var roll in GetRolls())
            {
                Assert.True(roll >= 0);
            }
        }

        [Fact]
        public void CanOnlyRollPinsLessThanOrEqualToTen()
        {
            for (int rollValue = 0; rollValue < 100; rollValue++)
            {
                Roll(rollValue);
            }

            foreach (var roll in GetRolls())
            {
                Assert.True(roll <= 10);
            }
        }

        [Fact]
        public void CannotExceed2RollsOnFrames1Through9()
        {
            for (int rollValue = 0; rollValue <= 10; rollValue++)
            {
                RollMany(rollValue, 25);

                var frames = GetFrames();
                for (int frame = 0; frame < 9; frame++)
                {
                    Assert.True(frames[frame].Scores.Count <= 2);
                }
                Game.NewGame();
            }
        }

        [Fact]
        public void CannotExceed2RollsOnFrame10_IfNoSpareOrStrike()
        {
            for (int rollValue = 0; rollValue <= 10; rollValue++)
            {
                RollMany(rollValue, 25);

                var frame = GetFrame(9);

                if (frame.IsSpare() || frame.IsStrike())
                {
                    Output.WriteLine($"{rollValue} leads to Spare or Strike. Skipping.");
                    Game.NewGame();
                    continue;
                }

                if (frame.Scores.Count <= 0)
                {
                    Output.WriteLine($"Game consisting of only {rollValue} pins per roll does not reach Frame 10. Skipping.");
                    Game.NewGame();
                    continue;
                }

                Output.WriteLine($"{frame}");
                Assert.True(frame.Scores.Count <= 2);
                Game.NewGame();
            }
        }

        [Fact]
        public void CannotExceed3RollsOnFrame10_IfSpareOrStrike()
        {
            for (int rollValue = 0; rollValue <= 10; rollValue++)
            {
                RollMany(rollValue, 25);

                var frame = GetFrame(9);
                if (!frame.IsSpare() && !frame.IsStrike())
                {
                    Output.WriteLine($"{rollValue} does not lead to Spare or Strike. Skipping.");
                    Game.NewGame();
                    continue;
                }

                Output.WriteLine($"{frame}");
                Assert.True(frame.Scores.Count <= 3);
                Game.NewGame();
            }
        }
        #endregion

        #region Misc Tests
        [Fact]
        public void GameCanBeReset()
        {
            RollMany(5, 6);
            Assert.True(GetRolls().Count == 6);
            Game.NewGame();
            RollMany(1, 2);
            Assert.True(GetRolls().Count == 2);
        }

        [Fact]
        public void CanGetScoreAtAnyTime()
        {
            for (var roll = 0; roll < 21; roll++)
            {
                Roll(5);
                Output.WriteLine($"Score on roll {roll}: {Game.Score}");
                Assert.True(Game.Score > 0);
            }
        }

        [Fact]
        public void UnplayedFramesAreNotNull()
        {
            for (int frame = 0; frame < 10; frame++)
            {
                Assert.NotNull(GetFrame(frame));
            }
        }
        #endregion

        private void Roll(int pointsEachRoll)
        {
            Game.AddRoll(pointsEachRoll);
        }

        private void RollMany(int pointsEachRoll, int numberOfRolls)
        {
            for (int roll = 0; roll < numberOfRolls; roll++)
            {
                Roll(pointsEachRoll);
            }
        }

        private void RollList(List<int> rolls)
        {
            for (int roll = 0; roll < rolls.Count; roll++)
            {
                Roll(rolls[roll]);
            }
        }

        private void PassIfExpectedRollCount(int expectedRollCount)
        {
            Assert.Equal(expectedRollCount, GetRolls().Count);
        }

        private List<int> GetRolls() => Game.PlayedRolls;

        private Frame GetFrame(int frameNumber)
        {
            return GetFrames()[frameNumber];
        }

        private List<Frame> GetFrames() => Game.Frames;

        private int GetScore() => Game.Score;
    }
}
