using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminictratorProject.Game.UpdateClasses.Buildings;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations.Metropolic;
using WebApplication1.Game.Locations.Metropolic.MetropolisMarketTraders;


namespace WebApplication1.Game.Locations
{
    
    public class Metropolis: CLocation
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
        public Metropolis(GInt counter,int? p) :base(counter, "Метрополис",p)
        {
            Description = "Стартовый город для новичков";
            SubLocations = new List<CLocation> { new TestTrader(counter, Id) };
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
