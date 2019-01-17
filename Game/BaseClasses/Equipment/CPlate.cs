namespace WebApplication1.Game.BaseClasses.Equipment
{
    public class CPlate:CEquipmentInventory
    {
        public CPlate()
        {
        }

        public CPlate(int id, CCultivator.CStats bonus) : base(id, bonus)
        {
        }
    }
}