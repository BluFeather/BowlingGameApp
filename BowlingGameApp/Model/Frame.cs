using System.Collections.Generic;
using System.Linq;

namespace BowlingGameApp.Model
{
    public class Frame
    {
        public List<int> Hits { get; protected set; } = new List<int>();

        public List<int> Bonuses { get; protected set; } = new List<int>();

        public int Score()
        {
            if (Hits.Count > 2) // Can only happen in 10th frame.
            {
                return 10 + Bonuses.Sum();
            }
            return Hits.Sum() + Bonuses.Sum();
        }

        public bool IsStrike()
        {
            return Hits.ElementAtOrDefault(0) == 10;
        }

        public bool IsSpare()
        {
            if (IsStrike()) return false;
            return Hits.ElementAtOrDefault(0) + Hits.ElementAtOrDefault(1) == 10;
        }

        public bool NeedsBonusPoints()
        {
            if (!IsSpare() && !IsStrike()) return false; 
            if (IsSpare() && Bonuses.Count >= 1) return false;
            if (IsStrike() && Bonuses.Count >= 2) return false;
            return true;
        }

        public void AddMissingBonus(int bonusPoints)
        {
            if (!NeedsBonusPoints()) return;
            Bonuses.Add(bonusPoints);
        }
    }
}
