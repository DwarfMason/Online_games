using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Game.UpdateClasses;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.NPC;
using WebApplication1.Game.UpdateClasses.NPC.Traders;

namespace WebApplication1.Game.Locations.NecropolisBuildings.MetropolisMarketTraders
{
    public class TestTrader:CDealer
    {
        public TestTrader(GInt gInt, int? p) : base(gInt, "Торговец С. О. Лями", p,
            new List<IBaseActions>
            {
                new DealerAction(new List<CItemInventory>
                    {
                        new CItemInventory(GItemsList.GetId("Палка")),                       
                    }
                    ,10)
                        ,
                new DealerAction(new List<CItemInventory>
                    { 
                        new CItemInventory(GItemsList.GetId("Говно"))                   
                    }
                    ,20),
                new DealerAction(new List<CItemInventory>
                    { 
                        new CItemInventory(GItemsList.GetId("Палка")),                   
                        new CItemInventory(GItemsList.GetId("Говно"))                   
                    }
                    ,300)
            },
            "/img/baryga.jpg"
        )
        {
            Description="Я вас категорически приветствую.\nПока вы осматриваете ассортимент,\nпредлагаю отведать наш новый эликсир здоровья.";
        }
    }
}