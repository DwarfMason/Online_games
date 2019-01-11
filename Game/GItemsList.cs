using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game
{
    public class GItemsList
    {
        public static SortedList<int,CItemDescription> ItemsList = new SortedList<int, CItemDescription>();
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

            if (ItemsList.Capacity != 0) throw new Exception("No Item with this name");
            new CItemDescription(0,"Палка","Просто палка");
            return 0;
        }
        public static void Add(CItemDescription i)
        {
            ItemsList[i.Id]=i;
        }
    }
}