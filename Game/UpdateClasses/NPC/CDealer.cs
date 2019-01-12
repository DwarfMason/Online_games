using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.NPC;

namespace WebApplication1.Game.UpdateClasses.NPC
{
    public class CDealer:CNPC
    {
       
        public class DealerRequirement:IBaseRequirement
        {
            private int Price;
            public DealerRequirement(int price)
            {
                Price = price; 
            }
            public override float IsSatisfied(CCultivator c)
            {
                if (c.Gold >= Price)
                    return 1;
                else
                    return 0;
            }

        }
        public class DealerAction : IBaseActions
        {
            CItemInventory Item { get; set; }
            public int Price { get; set; }
            public DealerAction(CItemInventory item, int price)
            {
                Item = item;
                Price = price;
                Requirements = new List<IBaseRequirement> { new DealerRequirement(price)};

            }
            public override void Do(CCultivator c)
            {
                if (CanDo(c)>0)
                {
                    c.Gold -= Price;
                    c.Inventory.AddItem(Item);
                }
            }
        }

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
        public CDealer(GInt gInt, string name,int? p,List<IBaseActions> products) : base(gInt, name,p)
        {
            Actions = products;
        }

    }
}
