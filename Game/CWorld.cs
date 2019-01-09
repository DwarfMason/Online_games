using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using AdministratorProject.Game;
using AdministratorProject.Game.BaseClasses;

namespace AdministratorProject.Game
{
    public class GWorld
    {
        public static GInt Counter = new GInt();
        public static CWorld World = new CWorld(Counter);
    }
    public class CWorld : CLocation
    {
        /*
        public string Description { get; set; }*
        public List<CLocation> SubLocations { get; set; }*
        public CLocation ParentLoc { get; set; }
        public List<CLocation> NeighboringLocs { get; set; }
        public List<LCLocation> Directions { get; set; }
        public List<LCMob> Mobs { get; set; } 
        public List<LCItems> Collectibles { get; set; }
        public List<LCMob> LegendaryMobs { get; set; }
        public List<IBaseActions> Actions { get; set; }
        */
        public List<CItemDescription> Items;

        public List<CEvents> EventNow;
        public List<CEvents> Event5Sec;
        public List<CEvents> Event5Min;
       
        public CWorld(GInt id) : base(id, "Элдария",0)
        {


            ///All World Inicialization 
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
