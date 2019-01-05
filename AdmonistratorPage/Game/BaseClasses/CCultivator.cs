using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.BaseClasses
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
                public float Strength { get; set; }
                public float Agility { get; set; }
                public float Intelligence { get; set; }
                public float Endurance { get; set; }

                public float Undistributed { get; set; } = 5;
            }
            public class CSubStats
            {
                public float Luck { get; set; }
                public float Charisma { get; set; }
                public float Perception { get; set; }
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

        public class CInventory
        {
            public List<CItemInventory> Items = new List<CItemInventory>();
            public void AddItem(CItemInventory item)
            {
                throw new NotImplementedException();//todo
            }


            public void DeleteItem(CItemInventory item)
            {
                throw new NotImplementedException();//todo
            }

        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string PlayerId { get; set; }
        public string Name { get; set; }

        public int Tier { get; set; } = 0;

        public CStats Stats { get; set; } = new CStats();

        public int Gold { get; set; } = 10;
        public int LocationId { get; set; } = 0;
        public CInventory Inventory { get; } = new CInventory(); 


    }
}
