using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.BaseClasses.Equipment;
using WebApplication1.Game.UpdateClasses.NPC.Traders;

namespace WebApplication1.Game.Locations.NecropolisBuildings.MetropolisMarketTraders
{
    public class AmuletTrader:CBaseEquipmentTrader
    {
        public AmuletTrader(GInt gInt, int? p) :
            base(gInt, "Торговец амулетами", p,new List<IBaseActions> 
            {
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CAmulet>(
                        1300,
                        new CCultivator.CStats(0,0,0,0,0,0,0,0.95,0.95,0.95,0.95),
                        new CCultivator.CStats(0,0,0,0,0,0,0,1.2,1.2,1.2,1.2),
                        5
                        ),20 
                    ),
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CAmulet>(
                        1301,
                        new CCultivator.CStats(0,0,0,0,0,0,0,1.1,1.1,1.1,1.1),
                        new CCultivator.CStats(0,0,0,0,0,0,0,2,2,2,2),
                        3
                        ),50
                    ), 
                new EquipmentTraderAction(
                    new CEquipmentGenerator<CAmulet>(
                        1302,
                        new CCultivator.CStats(0,0,0,0,0,0,0,0.4,0.4,0.4,0.4),
                        new CCultivator.CStats(0,0,0,0,0,0,0,3,3,3,3),
                        4
                        ),250
                    ), 
               
            },  "/img/weapon_trader.png")
        {
            Description="Я вас категорически приветствую.\nНет, мы раньше не виделись.\n Что значит видел такое тело?\nЛибо покупай амулеты, либо выметывайся!";
        }
    }
}
