using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.Game;

namespace WebApplication1.Game.BaseClasses
{
    public class СEventLocation
    {
        public SortedList<int, CCultivator> PlayersGathering = new SortedList<int, CCultivator>();
        private void CasualEvent(CCultivator cult)
        {
            Random rnd = new Random();
            int gold = rnd.Next(0 + rnd.Next(3, 18) + 100 * cult.Tier);
            CItemDescription item = GItemsList.ItemsList[rnd.Next(0,2)];
            cult.LastEvent = "После тщательного обследования каждого уголка локации вы нашли: " + gold + "золота и " + item.Name + "!";
        }

        private void MobBattle(CCultivator cult)
        {
            Random rnd = new Random();
            CMob enemy = GMobsList.MobsList[rnd.Next(0, GMobsList.MobsList.Count)];
            enemy.CalcStats(cult);

            int cultHp = (int) (3 + (cult.RealStats().MainStats.Endurance + rnd.Next(3,18)) / 5);
            int enemyHp = (int) (3 + (enemy.Endurance + rnd.Next(3,18)) / 5);

            while (cultHp > 0 && enemyHp > 0)
            {
               
            }

            if (cultHp <= 0)
            {
                cult.Gold -= enemy.Gold;
                cult.LastEvent = "Вы проиграли злодею, известному как" + enemy.Name +
                                 "и он благородно ограбил вас на " + enemy.Gold + " золота. Не плачьте!";
            }
            else
            {
                cult.Gold += enemy.Gold;
                cult.LastEvent = "Ну и зачем ты избил малыша" + enemy.Name +
                                 "еще и деньги забрали: " + enemy.Gold + " золота. Не злорадствуй, пока не побили!";
            }
        }
        
        
        
    }
}