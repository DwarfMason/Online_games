using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminictratorProject.Game.UpdateClasses.Buildings;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations.Metropolic.MetropolisMarketTraders;

namespace WebApplication1.Game.Locations.Metropolic
{
    public class MetropolisMarket : CMarket
    {
        public MetropolisMarket(GInt gInt, int? p) : base(gInt, "Рынок Метрополиса",p)
        {
            Description = "Пока есть только торговец палками";
            SubLocations = new List<CLocation>{new TestTrader(gInt,Id)};
            foreach (var i in SubLocations)
            {
                Directions.Add(new LCLocation
                {
                    LocationId = i.Id,
                    Time = 0
                });
            }
        }
    }
}