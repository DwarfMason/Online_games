namespace WebApplication1.Game.BaseClasses.Equipment
{
    public class CSword : CEquipmentInventory
    {
        public CSword()
        {
        }

        public CSword(int id, CCultivator.CStats bonus) : base(id, bonus)
        {
        }
    }
}