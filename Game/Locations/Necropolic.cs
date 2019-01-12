using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Game.UpdateClasses.Buildings;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations.NecropolicBuildings;
using WebApplication1.Game.Locations.NecropolicBuildings.MetropolisMarketTraders;


namespace WebApplication1.Game.Locations
{
    
    public class Necropolic: CTown
    {
        /*
        public string Description { get; set; }
        public List<CLocation> SubLocations { get; set; }
        public CLocation ParentLoc { get; set; }
        public List<CLocation> NeighboringLocs { get; set; }
        public List<LCLocation> Directions { get; set; }
        public List<LCMob> Mobs { get; set; } 
        public List<LCItems> Collectibles { get; set; }
        public List<LCMob> LegendaryMobs { get; set; }
        public List<IBaseActions> Actions { get; set; }
        */
        public Necropolic(GInt counter,int? p) :base(counter, "Метрополис",p,
            "/img/necropolis.jpg","")
        {
            Description = "Стартовый город для новичков";
            SubLocations = new List<CLocation> { new NecropolisMarket(counter, Id) };
            Directions = new List<LCLocation>();
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
