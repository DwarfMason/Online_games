using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminictratorProject.Game.UpdateClasses.Buildings;
using AdministratorProject.Game;
using AdministratorProject.Game.BaseClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.Locations
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
        Metropolis(GInt counter,int? p) :base(counter, "Метрополис",p)
        {
            Description = "Стартовый город для новичков";
            SubLocations = new List<CLocation> { new Metropolis_Market(counter, this.Id) };
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
        public class Metropolis_Market : CMarket
        {
            public Metropolis_Market(GInt gInt, int? p) : base(gInt, "Рынок Метрополиса",p)
            {
                Description = "Пока есть только торговец палками";

            }
        }
    }

    
}
