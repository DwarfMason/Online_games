using System.Collections.Generic;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations.NecropolisBuildings;
using WebApplication1.Game.Locations.NewTownBuildings;
using WebApplication1.Game.UpdateClasses.Buildings;

namespace WebApplication1.Game.Locations
{
    public class NewTown:CTown
    {
        public NewTown(GInt gInt, int? p) : base(gInt, "Город света", p, 
            "/img/newtown.jpg", "/img/newtown.jpg")
        { 
            Description = "новый город для продвинутых игроков";
            SubLocations = new List<CLocation>
            {
                new NewTownMarket(gInt,Id)
            };
            Directions = new List<LCLocation>();
            foreach (var i in SubLocations)
            {
                Directions.Add(new LCLocation
                {
                    LocationId = i.Id,
                    Time = 0
                });
            }
        }
    }
}