using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Models
{
    public class Comparator : IComparer<CCultivator>
    {
        public int Compare(CCultivator x, CCultivator y)
        {
            if (x.Tier < y.Tier)
                return 1;
            else if (x.Tier > y.Tier)
                return -1;
            else
                return 0;
        }
    }
}