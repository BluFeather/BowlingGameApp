using System.Collections.Generic;

namespace BowlingGameApp.Model
{
    public static class BowlingGameplayStatics
    {
        public static List<Frame> GetFrames(this BowlingGame bowlingGame)
        {
            List<Frame> frames = new List<Frame>(new Frame[10]);
            return frames;
        }
    }
}
