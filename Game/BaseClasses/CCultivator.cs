using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace WebApplication1.Game.BaseClasses
{

    public class CCultivator
    {
        public class CStats
        {
            public CMainStats MainStats { get; set; } = new CMainStats();
            public CSubStats SubStats { get; set; } = new CSubStats();
            public CScales Scales { get; set; } = new CScales();
            public class CMainStats
            {
                public float Strength { get; set; } = 5;
                public float Agility { get; set; } = 5;
                public float Intelligence { get; set; } = 5;
                public float Endurance { get; set; } = 5;

                public float Undistributed { get; set; } = 5;
            }
            public class CSubStats
            {
                public float Luck { get; set; } = 5;
                public float Charisma { get; set; } = 5;
                public float Perception { get; set; } = 5;
                public float Undistributed { get; set; } = 10;
            }
            public class CScales
            {
                public float Strength { get; set; } = 1;
                public float Agility { get; set; } = 1;
                public float Intelligence { get; set; } = 1;
                public float Endurance { get; set; } = 1;
            }

        }

        public static int GetStatPrice(float stat)
        {
            var a = (int)Math.Pow(10, stat.ToString().Length) + (int)stat * 4;
            var b = 0;
            for (int i = 1; i < stat; i++)
            {
                b += i.ToString().Length * 10;
            }

            return (a + b);
        }

        public class CInventory
        {
            [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
            public SortedDictionary<int ,CItemInventory> Items = new SortedDictionary<int, CItemInventory>();
            public void AddItem(CItemInventory item)
            {
                if (Items.ContainsKey(item.Id))
                {
                    Items[item.Id].Count+=item.Count;
                }
                else
                {
                    Items.Add(item.Id,item);
                }
            }


            public void DeleteItem(CItemInventory item)
            {
                if (Items.ContainsKey(item.Id))
                {
                    if (Items[item.Id].Count > 1)
                    {
                        Items[item.Id].Count--;
                    }
                    else
                    {
                        Items.Remove(item.Id);
                    }
                }
            }

        }

        public string Id { get; set; }
        
        [BsonId]
        public string PlayerId { get; set; }
        public string Name { get; set; }
        
        public int Tier { get; set; } = 0;

        public CStats Stats { get; set; } = new CStats();
        public string HeroType { get; set; }

        public int Gold { get; set; } = 10;
        public int LocationId { get; set; } = 0;
        public CInventory Inventory { get; set; } = new CInventory();


    }
}
