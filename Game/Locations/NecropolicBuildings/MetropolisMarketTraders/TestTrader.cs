using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Game.UpdateClasses;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.NPC;

namespace WebApplication1.Game.Locations.NecropolicBuildings.MetropolisMarketTraders
{
    public class TestTrader:CDealer
    {
        public TestTrader(GInt gInt, int? p) : base(gInt, "Торговец С. О. Лями", p,
            new List<IBaseActions>
            {
                new DealerAction(new CItemInventory(GItemsList.GetId("Палка"),1),10)
            },
            "/img/baryga.jpg"
        )
        {
            Description="Я вас категорически приветствую.\nПока вы осматриваете ассортимент,\nпредлагаю отведать наш новый эликсир здоровья.";
        }
    }
}