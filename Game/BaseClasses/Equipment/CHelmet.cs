namespace WebApplication1.Game.BaseClasses.Equipment
{
    public class CHelmet:CEquipmentInventory
    {
        public CHelmet()
        {
        }

        public CHelmet(int id, CCultivator.CStats bonus) : base(id, bonus)
        {
        }
    }
}