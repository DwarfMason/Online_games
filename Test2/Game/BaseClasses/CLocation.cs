using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.BaseClasses
{
    public class GLocationsList
    {
        public static SortedList<string, CLocation> LocationsNameList = new SortedList<string, CLocation>();
        public static SortedList<int, CLocation> LocationsIdList = new SortedList<int, CLocation>();
        public static CLocation GetName(string id)
        {
            return LocationsNameList[id];
        }
        public static void Add(CLocation i)
        {
            LocationsNameList.Add(i.Name, i);
            LocationsIdList.Add(i.Id, i);
        }
        public static CLocation GetId(int id)
        {
            return LocationsIdList[id];
        }

    }
    public class GInt
    {
        public int counter = 0;
    }
    public class CLocation
    {

        public class LCMob
        {
            public string Id { get; set; }
            public float Chance { get; set; }
            public float Known { get; set; } //todo
        }
        public class LCLocation
        {
            public int LocationId { get; set; }
            public int time { get; set; }
        }
        public class LCItems
        {
            public string Id { get; set; }
            public float Chance { get; set; }
            public float Known { get; set; } //todo
        }
        public CLocation(GInt id, string name)
        {
            Id = id.counter++;
            Name = name;
            GLocationsList.Add(this);
        }
        public CLocation()
        {
            throw new Exception("Not enought arguments"); 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CLocation> SubLocations { get; set; }
        public List<CLocation> NeighboringLocs { get; set; }
        public List<LCLocation> Directions { get; set; }
        public List<LCMob> Mobs { get; set; } 
        public List<LCItems> Collectibles { get; set; }
        public List<LCMob> LegendaryMobs { get; set; }
        public List<IBaseActions> Actions { get; set; }
       
    }
}
