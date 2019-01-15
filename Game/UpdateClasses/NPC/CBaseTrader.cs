using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game.UpdateClasses.NPC
{
    public class CBaseTrader:CNPC
    {
        public class  BaseTraderRequirement:IBaseRequirement
        {
            private int Price;
            public  BaseTraderRequirement(int price)
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
        public abstract class CTraderAction:IBaseActions
        {
            public List<CItemInventory> TraderItems { get; set; }
            public int Price { get; set; }
        }
        public CBaseTrader(GInt gInt, string name, int? p, string portret) : base(gInt, name, p, portret)
        {
            
        }
    }
}