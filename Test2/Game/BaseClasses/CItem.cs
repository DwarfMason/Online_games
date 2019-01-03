using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministratorProject.Game.BaseClasses
{
    public class GItemsList
    {
        public static SortedList<int,CItemDescription> ItemsList = new SortedList<int, CItemDescription>();
        public static CItemDescription Get(int id)
        {
            return ItemsList[id];
        }
        public static void Add(CItemDescription i)
        {
            ItemsList.Add(i.Id,i);
        }
    }
    public class CItemDescription
    {
        CItemDescription(int id, string name, string description, int rang)
        {
            if (GItemsList.ItemsList.ContainsKey(id))
            {
                throw new Exception("Item already exist");
            }
            Id = id;
            Name = name;
            Description = description;
            Rang = rang;
            GItemsList.Add(this);
        }
        public static explicit operator CInventoryItem(CItemDescription _in)
        {
            return new CInventoryItem(_in.Id, _in.Rang);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rang { get; set; }
    }
    public class CInventoryItem
    {
        public CInventoryItem()
        {
            Id = -1;
        }
        public CInventoryItem(int id, int rang)
        {
            Id = id;
            Rang = rang;
        }

        public int Id { get; set; }
        public int Rang { get; set; }
        public int Count { get; set; }
    }

}
