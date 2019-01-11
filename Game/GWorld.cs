using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using WebApplication1.Game;
using WebApplication1.Game.Locations;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game
{

    public static class GWorld
    {
        public static GInt Counter;
        public static CWorld World;

        public static void init()
        {
            Counter=new GInt();
            World=new CWorld(Counter);
        }
        
    }
}