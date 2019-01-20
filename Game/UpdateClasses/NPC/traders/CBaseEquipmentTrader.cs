using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.BaseClasses.Equipment;

namespace WebApplication1.Game.UpdateClasses.NPC.Traders
{
    public class CBaseEquipmentTrader:CBaseTrader
    {
        
        public class EquipmentTraderAction : CTraderAction
        {
            public IEquipmentGenerator EquipGenerator { get; set; }
            public EquipmentTraderAction(IEquipmentGenerator E, int price)
            {
                EquipGenerator = E;
                Price = price;
                Requirements = new List<IBaseRequirement> { new  BaseTraderRequirement(price)};
                TraderItems = new List<CItemInventory> {E.GenerateMax(), E.GenerateMin()};
            }
            public override void Do(CCultivator c)
            {
                if (CanDo(c)>0)
                {
                    c.Gold -= Price;
                    c.Equipments.AddEquip(EquipGenerator.Generate());
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
        public CBaseEquipmentTrader(GInt gInt, string name,int? p,List<IBaseActions> products, string por) : base(gInt, name,p,por)
        {
            Actions = products;
        }

    }    
}