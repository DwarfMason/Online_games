using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminictratorProject.Game.UpdateClasses;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.NPC;

namespace WebApplication1.Game.Locations.Metropolic.MetropolisMarketTraders
{
    public class TestTrader:CDealer
    {
        public TestTrader(GInt gInt, int? p) : base(gInt, "Тестовый торговец", p,
            new List<IBaseActions>
            {
                new DealerAction(new CItemInventory(GItemsList.GetId("Палка"),1),10)
            }
        
        )
        {
            
        }
    }
}