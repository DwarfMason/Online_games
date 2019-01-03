using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministratorProject.Game.BaseClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.UpdateClasses
{
    public class Dealer:NPC
    {
        /*
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CLocation> SubLocations { get; set; }
        public List<LCMob> Mobs { get; set; } 
        public List<LCItems> Collectibles { get; set; }
        public List<LCMob> LegendaryMobs { get; set; }
        public List<IBaseActions> Actions { get; set; }
        */
        public class DealerRequirement:IBaseRequirement
        {
            private int Price;
            public DealerRequirement(int price)
            {
                Price = price; 
            }
            public override float IsSatisfied(CCultivator c)
            {
                if ((c.Gold >= Price))
                    return 1;
                else
                    return 0;
            }

        }
        public class DealerAction : IBaseActions
        {
            public CItemDescription Item;
            DealerAction(CItemDescription Item, int price)
            {
                Requirements = new List<IBaseRequirement> { new DealerRequirement(price)};

            }
            public override void Do(CCultivator c)
            {
                if (CanDo(c)>0)
                {
                    c.Invenmtory.AddItem(Item);
                }
            }
        }
        public class DealerList
        {

        }
        Dealer(int id,DealerList items)
        {
            Id = id.ToString();


        }
       
    }
}
