using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Models
{
    public class ItemGridParams
    {
        public List<CItemInventory> Items;
        public int width = 6;
        public int height = 6;
        public int? SelectionId = null;
        public string ItemCssClass = "with-item";
        public string Action = null;
    }
}