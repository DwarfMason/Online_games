using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using WebApplication1.Game;
using WebApplication1.Game.BaseClasses;
using WebApplication1.Game.Locations;

namespace WebApplication1.Game
{

    public class CWorld : CLocation
    {
        public List<CItemDescription> Items;
        public List<CEvents> EventNow;
        public List<CEvents> Event5Sec;
        public List<CEvents> Event5Min;
        public Dictionary<int, List<CLocation>> Map; 
        public CWorld(GInt id) : base(id, "Элдария",0)
        {
            SubLocations=new List<CLocation>{
                new Necropolis(id,Id),
                new NewTown(id,Id),
            };
            // Ну и типа описываем наш граф.
            // Можно потом карту отображать в зависимости от 
            // текущей позиции героя. Хз как.
            // 
            Map = new Dictionary<int, List<CLocation>>();
            Map[SubLocations[0].Id]= new List<CLocation>
            {
                SubLocations[1],
            };
            Map[SubLocations[1].Id]= new List<CLocation>
            {
                SubLocations[2],
            };
        }
        public void updateNow()
        {
            throw new NotImplementedException();//todo
        }
        public void update5Min()
        {
            throw new NotImplementedException();//todo
        }
        public void update5Sec()
        {
            throw new NotImplementedException();//todo
        }
 


    }
}
