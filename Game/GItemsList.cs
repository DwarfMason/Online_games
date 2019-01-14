using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.BaseClasses.Equipment;

namespace WebApplication1.Game
{
    public class GItemsList
    {
        public static SortedList<int, CItemDescription> ItemsList = new SortedList<int, CItemDescription>();

        public static CItemDescription Get(int id)
        {
            return ItemsList[id];
        }

        public static int GetId(string name)
        {
            foreach (var i in ItemsList)
            {
                if (i.Value.Name == name)
                {
                    return i.Value.Id;
                }
            }
            throw new Exception("No Item with this name");
        }

        public static void Add(CItemDescription i)
        {
            ItemsList[i.Id] = i;
        }

        public static void init()
        {
            new CItemDescription(0, "Палка", 
                "Палка, покрытая золотой пылью. Ничего необычного, если бы пыль не была ангельской.",
                "/img/stick.png");
            new CEquipmentDescription(1, "Легинсы", "", "");
        }
    }
}