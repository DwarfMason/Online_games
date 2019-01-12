using WebApplication1.Game.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Game.UpdateClasses.Buildings
{
    public class CMarket:CBuilding
    {
        public CMarket(GInt gInt, string name, int? p, string BigP, string SmallP) : base(gInt, name, p, BigP, SmallP)
        {
        }
    }
}
