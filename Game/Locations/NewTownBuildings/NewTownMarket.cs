using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations.NecropolisBuildings.MetropolisMarketTraders;
using WebApplication1.Game.UpdateClasses.Buildings;

namespace WebApplication1.Game.Locations.NewTownBuildings
{
    public class NewTownMarket: CMarket
    {
        public NewTownMarket(GInt gInt, int? p) : base(gInt, "Рынок города света",p,
            "/img/shop-icon.png","/img/shop-icon.png")
        {
            Description = "";
            SubLocations = new List<CLocation>
            {
                new SwordTrader(gInt,Id),
                new AmuletTrader(gInt,Id),
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