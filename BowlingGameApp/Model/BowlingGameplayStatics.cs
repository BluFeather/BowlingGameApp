using System.Collections.Generic;

namespace BowlingGameApp.Model
{
    public static class BowlingGameplayStatics
    {
        public static List<Frame> GetFrames(this BowlingGame bowlingGame)
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < 10; i++)
            {
                List<int> hits = new List<int>();
                int score = 0;
                frames.Add(new Frame(hits, score));
            }
            return frames;
        }
    }
}
