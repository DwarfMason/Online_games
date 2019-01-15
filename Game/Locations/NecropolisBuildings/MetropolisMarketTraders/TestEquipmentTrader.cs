using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.BaseClasses.Equipment;
using WebApplication1.Game.UpdateClasses.NPC;
using WebApplication1.Game.UpdateClasses.NPC.Traders;

namespace WebApplication1.Game.Locations.NecropolisBuildings.MetropolisMarketTraders
{
    public class TestEquipmentTrader:CBaseEquipmentTrader
    {
        public TestEquipmentTrader(GInt gInt, int? p) :
            base(gInt, "тестовый торговец оружием", p,new List<IBaseActions> 
            {
            new EquipmentTraderAction(new CEquipmentGenerator<CLeggins>(1000,
                new CCultivator.CStats(0,0,0,0,0,0,0,0.5,0.5,0.5,0.5),
                new CCultivator.CStats(3,3,3,3,3,3,3,2,2,2,2)
                , 0)// Матожидание распределения
                , 1)////Цена
            },  "/img/baryga.jpg")
        {
        }
    }
}