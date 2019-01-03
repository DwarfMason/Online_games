using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministratorProject.Game;
using AdministratorProject.Game.BaseClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.Locations
{
    public class Metropolis: CLocation
    {
        /*
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CLocation> SubLocations { get; set; } = new List<CLocation>();
        public List<LCMob> Mobs { get; set; } = new List<LCMob>();
        public List<LCItems> Collectibles { get; set; } = new List<LCItems>();
        public List<LCMob> LegendaryMobs { get; set; }
        public List<IBaseActions> Actions { get; set; }
        */
        Metropolis(int id)
        {
            Id = id.ToString();
            Name = "Метрополис";
            Description = "Стартовый город для новичков";


        }
        public class Metropolis_Market : CLocation
        {
            Metropolis_Market(int id)
            {
                Id = id.ToString();
                Name = "Центральный рынок Метрополиса";
                Description = "Пока есть только торговец палками";

            }
        }
    }

    
}
