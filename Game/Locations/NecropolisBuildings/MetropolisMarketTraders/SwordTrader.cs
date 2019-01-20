using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.BaseClasses.Equipment;
using WebApplication1.Game.UpdateClasses.NPC;
using WebApplication1.Game.UpdateClasses.NPC.Traders;

namespace WebApplication1.Game.Locations.NecropolisBuildings.MetropolisMarketTraders
{
    public class SwordTrader:CBaseEquipmentTrader
    {
        public SwordTrader(GInt gInt, int? p) :
            base(gInt, "Торговец мечами", p,new List<IBaseActions> 
            {
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CSword>(
                        1200,
                        new CCultivator.CStats(1,1,1,1,1,1,1,1,1,1,1),
                        new CCultivator.CStats(2,2,2,2,2,2,2,1,1,1,1),
                        5
                        ),10 
                    ),
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CSword>(
                        1201,
                        new CCultivator.CStats(1,1,1,1,1,1,1,1,1,1,1),
                        new CCultivator.CStats(10,10,10,10,10,10,10,1,1,1,1),
                        3
                        ),100
                    ), 
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CSword>(
                        1202,
                        new CCultivator.CStats(4,4,4,4,4,4,4,1,1,1,1),
                        new CCultivator.CStats(5,5,5,5,5,5,5,1,1,1,1),
                        6
                        ),75
                    ), 
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CSword>(
                        1203,
                        new CCultivator.CStats(2,2,2,2,2,2,2,1,1,1,1),
                        new CCultivator.CStats(4,4,4,4,4,4,4,1,1,1,1),
                        4
                        ),25
                    ), 
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CSword>(
                        1204,
                        new CCultivator.CStats(9,9,9,9,9,9,9,1,1,1,1),
                        new CCultivator.CStats(15,15,15,15,15,15,15,1,1,1,1),
                        4
                        ),200
                    ),
            },  "/img/weapon_trader.png")
        {
            Description="Я вас категорически приветствую.\nНет, мы раньше не виделись.\n Что значит видел такое тело?\nЛибо покупай мечи, либо выметывайся!";
        }
    }
}