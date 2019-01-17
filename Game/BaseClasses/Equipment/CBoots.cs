namespace WebApplication1.Game.BaseClasses.Equipment
{
    public class CBoots:CEquipmentInventory
    {
        public CBoots()
        {
        }

        public CBoots(int id, CCultivator.CStats bonus) : base(id, bonus)
        {
        }
    }
}