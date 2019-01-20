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
            cult.Event.lastEventStory = "После тщательного обследования каждого уголка локации вы нашли: " + gold + "золота и " + item.Name + "!";
        }

        private CMob MobBattle(CCultivator cult)
        {
            cult.Event = new CCultivator.LastEvent();
            Random rnd = new Random();
            CMob enemy = GMobsList.MobsList[rnd.Next(0, GMobsList.MobsList.Count)];
            enemy.CalcStats(cult);

            int cultHp = (int) (3 + (cult.RealStats().MainStats.Endurance + rnd.Next(3,18)) / 5);
            int enemyHp = (int) (3 + (enemy.Endurance + rnd.Next(3,18)) / 5);

            int cultStr = (int)cult.RealStats().MainStats.Strength;
            int cultAgility = (int) cult.RealStats().MainStats.Agility;
            int cultInt = (int) cult.RealStats().MainStats.Intelligence;
            

            while (!IsDead(cultHp, enemyHp))
            {
                
                // Agility damage + crit
                var agilityDamage = cultAgility > enemy.Agility
                    ? (int) (Difference(cultAgility, enemy.Agility) * rnd.Next(3, 18) - rnd.Next(3, 18))
                    : (int) (rnd.Next(3, 18) - Difference(cultAgility, enemy.Agility) * rnd.Next(3, 18));
                
                bool crit = rnd.Next(1, 20) > 18;
                
                if (agilityDamage >= 0)
                {
                    enemyHp -= agilityDamage + agilityDamage * (crit ? 1 : 0);
                    cult.Event.Crits += crit ? 1 : 0;
                }
                else
                {
                    cultHp -= agilityDamage + agilityDamage * (crit ? 1 : 0);
                }
                
                if (IsDead(cultHp, enemyHp))
                {
                    break;
                }
                
                // Str scope
                var strengthDamage = cultStr > enemy.Strength
                    ? (int) (Difference(cultStr, enemy.Strength) * rnd.Next(3, 18) - rnd.Next(3, 18))
                    : (int) (rnd.Next(3, 18) - Difference(cultStr, enemy.Strength) * rnd.Next(3, 18));
                
                bool overTry = rnd.Next(1, 20) > 18;
                
                if (strengthDamage >= 0)
                {
                    enemyHp -= strengthDamage * (overTry ? 0 : 1);
                    cult.Event.TriesHard += overTry ? 1 : 0;
                }
                else
                {
                    cultHp -= strengthDamage * (overTry ? 0 : 1);
                }
                
                if (IsDead(cultHp, enemyHp))
                {
                    break;
                }
                
                //Int scope
                var intDamage = cultInt > enemy.Intelligence
                    ? (int) (Difference(cultInt, enemy.Intelligence) * rnd.Next(3, 18) - rnd.Next(3, 18))
                    : (int) (rnd.Next(3, 18) - Difference(cultInt, enemy.Intelligence) * rnd.Next(3, 18));
                
                bool heal = rnd.Next(1, 20) > 18;
                
                if (intDamage >= 0)
                {
                    if (heal)
                    {
                        cultHp += intDamage;
                        cult.Event.Heals++;
                    }
                    else
                    {
                        enemyHp -= intDamage;
                    }
                }
                else
                {
                    if (heal)
                    {
                        enemyHp += intDamage;
                    }
                    else
                    {
                        cultHp -= intDamage;
                    }
                }
            }
            
            if (cultHp <= 0)
            {
                cult.Gold = Math.Max(cult.Gold - enemy.Gold, 0);
                cult.Event.lastEventStory = "Вы проиграли злодею, известному как" + enemy.Name +
                                 "и он благородно ограбил вас на " + enemy.Gold + " золота. Не плачьте!\n";
                cult.Points = Math.Max(0, cult.Points - 1);
            }
            else
            {
                cult.Gold += enemy.Gold;
                cult.Points += enemy.Difficulty;
                cult.Event.lastEventStory = "Ну и зачем ты избил малыша" + enemy.Name +
                                 "\n еще и деньги забрали: " + enemy.Gold + " золота.\nНе злорадствуй, пока не побили!\n";
            }
            return enemy;
        }

        private static bool IsDead(int cultHp, int enemyHp)
        {
            return cultHp <= 0 && enemyHp <= 0;
        }

        private static double Difference(double cultStat, double enemyStat)
        {
            return Math.Max((int)(Math.Min(cultStat, enemyStat) / Math.Max(cultStat, enemyStat) * 100), 0.1);
        }
        
    }
}