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
                new CCultivator.CStats(0,0,0,0,0,0,0,1,1,1,1),
                new CCultivator.CStats(3,3,3,3,3,3,3,1,1,1,1)
                , 3)// Матожидание распределения
                , 1),//Цена
                new EquipmentTraderAction(new CEquipmentGenerator<CLeggins>(1001,
                        new CCultivator.CStats(1,1,1,1,0,0,0,1,1,1,1),
                        new CCultivator.CStats(5,5,5,5,3,3,3,1,1,1,1)
                        , 4)
                    , 30),
                new EquipmentTraderAction(new CEquipmentGenerator<CPlate>(1010,
                        new CCultivator.CStats(0,0,0,0,0,0,0,1,1,1,1),
                        new CCultivator.CStats(3,3,3,3,3,3,3,1,1,1,1)
                        , 7)// Матожидание распределения
                    , 1)////Цена
            },  "/img/weapon_trader.png")
        {
            Description="Я вас категорически приветствую.\nНет, мы раньше не виделись.\n Что значит видел такое тело?\nЛибо покупай товар, либо выметывайся!";
        }
    }
}