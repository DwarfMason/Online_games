using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.UpdateClasses.Buildings;

namespace WebApplication1.Game.Locations
{
    public class NewTown:CTown
    {
        public NewTown(GInt gInt, int? p) : base(gInt, "Новый город(Вставьте имя)", p, 
            "здесь ссылка на большую картинку", "здесь ссылка на маленькую картинку")
        {
        }
    }
}