namespace WebApplication1.Game.BaseClasses.Equipment
{
    public class CLeggins:CEquipmentInventory
    {
        public CLeggins()
        {
        }

        public CLeggins(int id, CCultivator.CStats bonus) : base(id, bonus)
        {
        }
    }
}