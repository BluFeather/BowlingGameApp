﻿using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class BowlingGame
    {
        /// <summary>
        /// List containing the values of each played roll.
        /// </summary>
        public List<int> Rolls => GetRollsFromFrames(Frames);

        /// <summary>
        /// Contains objects representing a single turn.
        /// </summary>
        public List<Frame> Frames { get; protected set; } = new List<Frame>();

        /// <summary>
        /// Resets the state of the game.
        /// </summary>
        public void ResetGame()
        {
            ResetFrames();
            frameIndex = 0;
        }

        /// <summary>
        /// Adds the result of a roll to the game's score.
        /// </summary>
        /// <param name="points">Number of pins knocked down.</param>
        public void AddRoll(int points)
        {
            GetCurrentFrame().AddRoll(points);

            foreach (var frame in Frames)
            {
                frame.AddBonusPoints(points);
            }

            if (!FrameIsCompleted(points)) return;
            if (IsFinalFrame()) return;
            GoToNextFrame();
        }

        /// <summary>
        /// Calculates the game's final score.
        /// </summary>
        /// <returns>Integer representation of the game's final score.</returns>
        public int CalculateFinalScore()
        {
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10;
                    score += StrikeBonus(rollIndex);
                    rollIndex += 1;
                    continue;
                }

                if (IsSpare(rollIndex))
                {
                    score += 10;
                    score += SpareBonus(rollIndex);
                    rollIndex += 2;
                    continue;
                }

                score += Rolls[rollIndex] + Rolls[rollIndex + 1];
                rollIndex += 2;
            }

            return score;
        }

        private int frameIndex = 0;

        private void ResetFrames()
        {
            Frames.Clear();
            for (int frame = 0; frame < 10; frame++)
            {
                Frames.Add(new Frame());
            }
        }

        private void GoToNextFrame()
        {
            frameIndex++;
        }

        private Frame GetCurrentFrame()
        {
            if (Frames.ElementAtOrDefault(frameIndex) == null)
            {
                Frames.Add(new Frame());
            }
            return Frames[frameIndex];
        }

        private bool IsStrike(int rollIndex)
        {
            return Rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return Rolls[rollIndex] + Rolls[rollIndex + 1] == 10;
        }

        private int StrikeBonus(int rollIndex)
        {
            return Rolls[rollIndex + 1] + Rolls[rollIndex + 2];
        }

        private int SpareBonus(int rollIndex)
        {
            return Rolls[rollIndex + 2];
        }

        private List<int> GetRollsFromFrames(List<Frame> frames)
        {
            List<int> rolls = new List<int>();
            foreach (Frame frame in frames)
            {
                rolls.AddRange(frame.Scores);
            }
            return rolls;
        }

        private bool FrameIsCompleted(int value)
        {
            return Frames[frameIndex].Scores.Count >= 2 || value == 10;
        }

        private bool IsFinalFrame()
        {
            return frameIndex >= 9;
        }
    }
}
