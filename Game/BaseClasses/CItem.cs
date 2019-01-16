using System;

namespace WebApplication1.Game.BaseClasses
{
    public class CItemDescription
    {
        public CItemDescription(int id, string name, string description, string picture)
        {
            if (GItemsList.ItemsList.ContainsKey(id))
            {
                throw new Exception("Item already exist");
            }
            Id = id;
            Name = name;
            Description = description;
            Picture = picture;
            GItemsList.Add(this);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
    public class CItemInventory
    {
        
        public CItemInventory(int id)
        {
            Id = id;
            Count = 1;
        }
        public CItemInventory(int id,int c)
        {
            Id = id;
            Count = c;
        }
        public CItemInventory()
        {
        }

        public CItemInventory Copy()
        {
            CItemInventory out_ = new CItemInventory();
            out_.Count = Count;
            out_.Id = Id;
            return out_;
        }
        public CItemDescription Description()
        {
            return GItemsList.Get(this.Id);
        }
        public int Id { get; set; }
        public int Count { get; set; }
    }

}
