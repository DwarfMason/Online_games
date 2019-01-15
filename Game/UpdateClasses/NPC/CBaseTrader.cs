using System.Security.Cryptography.X509Certificates;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game.UpdateClasses.NPC
{
    public class CBaseTrader:CNPC
    {
        
        public abstract class CTraderAction:IBaseActions
        {
            public CItemInventory ItemInventory { get; set; }
            public int Price { get; set; }
        }
        public CBaseTrader(GInt gInt, string name, int? p, string portret) : base(gInt, name, p, portret)
        {
            
        }
    }
}