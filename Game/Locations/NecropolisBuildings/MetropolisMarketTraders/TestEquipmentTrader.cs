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
            base(gInt, "В. О. Лоеб", p,new List<IBaseActions> 
            {
            new EquipmentTraderAction(new CEquipmentGenerator<CLeggins>(1000,
                new CCultivator.CStats(0,0,0,0,0,0,0,0.5,0.5,0.5,0.5),
                new CCultivator.CStats(3,3,3,3,3,3,3,2,2,2,2)
                , 5)// Матожидание распределения
                , 1)////Цена
            },  "/img/weapon_trader.png")
        {
            Description="Я вас категорически приветствую.\nНет, мы раньше не виделись.\n Что значит видел такое тело?\nЛибо покупай товар, либо выметывайся!";
        }
    }
}