using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.NPC;

namespace WebApplication1.Game.UpdateClasses.NPC.Traders
{
    public class CDealer:CBaseTrader
    {

        public class DealerAction : CTraderAction
        {
            public DealerAction(List<CItemInventory> items, int price)
            {
                TraderItems = items;
                Price = price;
                Requirements = new List<IBaseRequirement> { new BaseTraderRequirement(price)};

            }
            public override void Do(CCultivator c)
            {
                if (CanDo(c)>0)
                {
                    c.Gold -= Price;
                    foreach (var item in TraderItems)
                    {
                        c.Inventory.AddItem(item);
                    }
                   
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
        public CDealer(GInt gInt, string name,int? p,List<IBaseActions> products, string por) : base(gInt, name,p,por)
        {
            Actions = products;
        }

    }
}
