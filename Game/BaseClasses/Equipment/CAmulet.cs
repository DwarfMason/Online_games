namespace WebApplication1.Game.BaseClasses.Equipment
{
    public class CAmulet:CEquipmentInventory
    {
        public CAmulet()
        {
        }

        public CAmulet(int id, CCultivator.CStats bonus) : base(id, bonus)
        {
        }
    }
}