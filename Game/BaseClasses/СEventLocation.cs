using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Driver;
using WebApplication1.Game;
using System.Threading;
using MongoDB.Bson.Serialization.Serializers;

namespace WebApplication1.Game.BaseClasses
{
    public class СEventLocation
    {
        private Stack<CCultivator> PlayersGathering = new Stack<CCultivator>();

        public void Add(CCultivator cult)
        {
            PlayersGathering.Push(cult);
            cult.IsInAction = true;
            Instructions(cult);
            CreateAdventure(cult);
            PlayersGathering.Pop();
        }

        static void Instructions(CCultivator cult)
        {
            Thread.CurrentThread.IsBackground = true;
            Thread.Sleep(30000);
            if (cult.Points > 10)
            {
                cult.Points -= 10;
                cult.Tier++;
            }
            cult.IsInAction = false;
        }

        
        private void CreateAdventure(CCultivator cult)
        {
            Random rnd = new Random();
            int choice = rnd.Next(0, 2);
            switch(choice)
            {
                case 0 :
                    CasualEvent(cult);
                    break;
                case 1 :
                    PvPBattle(cult);
                    break;
                case 2 :
                   MobBattle(cult);
                    break;
            }
        }
       
        
        private void CasualEvent(CCultivator cult)
        {
            Random rnd = new Random();
            int gold = rnd.Next(0, rnd.Next(3, 18) + 100 * cult.Tier);
            CItemDescription item = GItemsList.ItemsList[rnd.Next(0,2)];
            cult.Gold += gold;
            cult.Inventory.AddItem(new CItemInventory(item.Id));
            cult.Event.LastEventStory = "После тщательного обследования каждого уголка локации вы нашли: " + gold + " золота и " + item.Name + "!";
            cult.Points++;
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
            

            while (IsNotDead(cultHp, enemyHp))
            {
                
                // Agility damage + crit
                var agilityDamage = cultAgility > enemy.Agility
                    ? (int) (Difference(cultAgility, enemy.Agility) * rnd.Next(3, 18) + rnd.Next(3, 18) - rnd.Next(3, 18))
                    : (int) (rnd.Next(3, 18) - Difference(cultAgility, enemy.Agility) * rnd.Next(3, 18) + rnd.Next(3, 18));
                
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
                
                if (!IsNotDead(cultHp, enemyHp))
                {
                    break;
                }
                
                // Str scope
                var strengthDamage = cultStr > enemy.Strength
                    ? (int) (Difference(cultStr, enemy.Strength) * rnd.Next(3, 18) + rnd.Next(3, 18) - rnd.Next(3, 18))
                    : (int) (rnd.Next(3, 18) - Difference(cultStr, enemy.Strength) * rnd.Next(3, 18) + rnd.Next(3, 18));
                
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
                
                if (!IsNotDead(cultHp, enemyHp))
                {
                    break;
                }
                
                //Int scope
                var intDamage = cultInt > enemy.Intelligence
                    ? (int) (Difference(cultInt, enemy.Intelligence) * rnd.Next(3, 18) + rnd.Next(3, 18) - rnd.Next(3, 18))
                    : (int) (rnd.Next(3, 18) - Difference(cultInt, enemy.Intelligence) * rnd.Next(3, 18) + rnd.Next(3, 18));
                
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
                cult.Event.LastEventStory = "Вы проиграли злодею, известному как" + enemy.Name +
                                 " и он благородно ограбил вас на " + enemy.Gold + " золота. Не плачьте!\n";
                cult.Points = Math.Max(0, cult.Points - 1);
            }
            else
            {
                cult.Gold += enemy.Gold;
                cult.Points += enemy.Difficulty;
                cult.Event.LastEventStory = "Ну и зачем ты избил малыша " + enemy.Name +
                                 "\n еще и деньги забрали: " + enemy.Gold + " золота.\nНе злорадствуй, пока не побили!\n";
            }
            return enemy;
        }
        
        
        
        private void PvPBattle(CCultivator cult1)
        {
            cult1.Event = new CCultivator.LastEvent();
            if (PlayersGathering.Count < 1)
            {
                cult1.Event.LastEventStory = "Никого нет, увы.";
            }
            else
            {
                Random rnd = new Random();
                CCultivator cult2 = PlayersGathering.Peek();
                while (cult1 == cult2)
                {
                    cult2 = PlayersGathering.Peek();
                }
                cult2.Event = new CCultivator.LastEvent();

                int cult1Hp = (int) (3 + (cult1.RealStats().MainStats.Endurance + rnd.Next(3, 18)) / 5);
                int cult1Str = (int) cult1.RealStats().MainStats.Strength;
                int cult1Agility = (int) cult1.RealStats().MainStats.Agility;
                int cult1Int = (int) cult1.RealStats().MainStats.Intelligence;
                
                int cult2Hp = (int) (3 + (cult2.RealStats().MainStats.Endurance + rnd.Next(3, 18)) / 5);
                int cult2Str = (int) cult1.RealStats().MainStats.Strength;
                int cult2Agility = (int) cult1.RealStats().MainStats.Agility;
                int cult2Int = (int) cult1.RealStats().MainStats.Intelligence;


                while (IsNotDead(cult1Hp, cult2Hp))
                {

                    // Agility damage + crit
                    var agilityDamage = cult1Agility > cult2Agility
                        ? (int) (Difference(cult1Agility, cult2Agility) * rnd.Next(3, 18) + rnd.Next(3, 18) -
                                 rnd.Next(3, 18))
                        : (int) (rnd.Next(3, 18) - Difference(cult1Agility, cult2Agility) * rnd.Next(3, 18) +
                                 rnd.Next(3, 18));

                    bool crit = rnd.Next(1, 20) > 18;

                    if (agilityDamage >= 0)
                    {
                        cult2Hp -= agilityDamage + agilityDamage * (crit ? 1 : 0);
                        cult1.Event.Crits += crit ? 1 : 0;
                    }
                    else
                    {
                        cult1Hp -= agilityDamage + agilityDamage * (crit ? 1 : 0);
                        cult2.Event.Crits += crit ? 1 : 0;
                    }

                    if (!IsNotDead(cult1Hp, cult2Hp))
                    {
                        break;
                    }

                    // Str scope
                    var strengthDamage = cult1Str > cult2Str
                        ? (int) (Difference(cult1Str, cult2Str) * rnd.Next(3, 18) + rnd.Next(3, 18) -
                                 rnd.Next(3, 18))
                        : (int) (rnd.Next(3, 18) - Difference(cult1Str, cult2Str) * rnd.Next(3, 18) +
                                 rnd.Next(3, 18));

                    bool overTry = rnd.Next(1, 20) > 18;

                    if (strengthDamage >= 0)
                    {
                        cult2Hp -= strengthDamage * (overTry ? 0 : 1);
                        cult1.Event.TriesHard += overTry ? 1 : 0;
                    }
                    else
                    {
                        cult1Hp -= strengthDamage * (overTry ? 0 : 1);
                        cult2.Event.TriesHard += overTry ? 1 : 0;
                    }

                    if (!IsNotDead(cult1Hp, cult2Hp))
                    {
                        break;
                    }

                    //Int scope
                    var intDamage = cult1Int > cult2Int
                        ? (int) (Difference(cult1Int, cult2Int) * rnd.Next(3, 18) + rnd.Next(3, 18) -
                                 rnd.Next(3, 18))
                        : (int) (rnd.Next(3, 18) - Difference(cult1Int, cult2Int) * rnd.Next(3, 18) +
                                 rnd.Next(3, 18));

                    bool heal = rnd.Next(1, 20) > 18;

                    if (intDamage >= 0)
                    {
                        if (heal)
                        {
                            cult1Hp += intDamage;
                            cult1.Event.Heals++;
                        }
                        else
                        {
                            cult2Hp -= intDamage;
                        }
                    }
                    else
                    {
                        if (heal)
                        {
                            cult2Hp += intDamage;
                            cult2.Event.Heals++;
                        }
                        else
                        {
                            cult1Hp -= intDamage;
                        }
                    }
                }

                if (cult1Hp <= 0)
                {
                    int goldToLose = (int) (cult1.Gold * 0.2);
                    cult2.Gold += goldToLose;
                    cult1.Gold -= goldToLose;
                    cult1.Event.LastEventStory = "Вы проиграли злодею, известному как" + cult2.Name +
                                                " и он благородно ограбил вас на " + goldToLose +
                                                " золота. Не плачьте!\n Хотя бы не бот!";
                    cult2.Event.LastEventStory = "Ну и зачем ты избил малыша " + cult1.Name +
                                                "\n еще и деньги забрали: " + goldToLose +
                                                " золота.\nНе злорадствуй, пока не побили!\n";
                    cult1.Points = Math.Max(0, cult1.Points - 1);
                    cult2.Points += 5;
                }
                else
                {
                    int goldToLose = (int) (cult2.Gold * 0.2);
                    cult1.Gold += goldToLose;
                    cult2.Gold -= goldToLose;
                    cult2.Event.LastEventStory = "Вы проиграли злодею, известному как" + cult1.Name +
                                                 " и он благородно ограбил вас на " + goldToLose +
                                                 " золота. Не плачьте!\n Хотя бы не бот!";
                    cult1.Event.LastEventStory = "Ну и зачем ты избил малыша " + cult2.Name +
                                                 "\n еще и деньги забрали: " + goldToLose +
                                                 " золота.\nНе злорадствуй, пока не побили!\n";
                    cult2.Points = Math.Max(0, cult2.Points - 1);
                    cult1.Points += 5;
                }

                
            }
        }

        private static bool IsNotDead(int cultHp, int enemyHp)
        {
            return cultHp > 0 && enemyHp > 0;
        }

        private static double Difference(double cultStat, double enemyStat)
        {
            return Math.Max((int)(Math.Min(cultStat, enemyStat) / Math.Max(cultStat, enemyStat) * 100), 0.1) / 100.00;
        }
        
    }
}