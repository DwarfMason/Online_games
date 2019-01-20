using System;
using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game
{
    public class GMobsList
    {
        public static SortedList<int, CMob> MobsList = new SortedList<int, CMob>();

        public static CMob Get(int id)
        {
            return MobsList[id];
        }

        public static int GetId(string name)
        {
            foreach (var i in MobsList)
            {
                if (i.Value.Name == name)
                {
                    return i.Value.Id;
                }
            }
            throw new Exception("No Mob with this name");
        }

        public static void Add(CMob i)
        {
            MobsList[i.Id] = i;
        }

        public static void init()
        {
            new CMob(0, 1, "Мышь", "Кродёться", "/img/mouse.jpg");
            new CMob(1, 2, "Слизень", "Когда-то у него не было девушки", "/img/slime.png");
            new CMob(2, 6, "Разрабы", "Надеюсь они не доживут до релиза", "/img/developers.png");
            new CMob(3, 3, "Тренировочная кукла", "Даже она тебя изобьет", "/img/maniquen.png");
            new CMob(4, 5, "Страшная книга", "Не, ну а че там буквы", "/img/book.png");
        }
    }
}