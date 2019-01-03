using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.BaseClasses
{
    public class CLocation
    {
        public class LCMob
        {
            public string Id { get; set; }
            public float Chance { get; set; }
            public float Known { get; set; } //todo
        }
        public class LCItems
        {
            public string Id { get; set; }
            public float Chance { get; set; }
            public float Known { get; set; } //todo
        }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CLocation> SubLocations { get; set; }
        public List<LCMob> Mobs { get; set; } 
        public List<LCItems> Collectibles { get; set; }
        public List<LCMob> LegendaryMobs { get; set; }
        public List<IBaseActions> Actions { get; set; }
    }
}
