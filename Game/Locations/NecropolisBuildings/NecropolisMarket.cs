using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Game.UpdateClasses.Buildings;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations.NecropolisBuildings.MetropolisMarketTraders;

namespace WebApplication1.Game.Locations.NecropolisBuildings
{
    public class NecropolisMarket : CMarket
    {
        public NecropolisMarket(GInt gInt, int? p) : base(gInt, "Рынок Метрополиса",p,
            "/img/shop-icon.png","/img/shop-icon.png")
        {
            Description = "Пока есть только торговец палками";
            SubLocations = new List<CLocation>
            {
                new TestTrader(gInt,Id),
                new TestEquipmentTrader(gInt,Id),
                new SwordTrader(gInt,Id),
            };
            Directions=new List<LCLocation>();
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