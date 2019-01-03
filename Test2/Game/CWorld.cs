using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using AdministratorProject.Game;
using AdministratorProject.Game.BaseClasses;

namespace AdministratorProject.Game
{
    public class CWorld:CLocation
    {
        private static CWorld instance;
        private static object syncRoot = new Object();

        public List<CItemDescription> Items;

        public List<CEvents> EventNow;
        public List<CEvents> Event5Sec;
        public List<CEvents> Event5Min;

        private CWorld()
        {
            Name = "Элдария";
            
            ///All World Inicialization 
        }
        public static CWorld GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new CWorld();
                }
            }
            return instance;
        }


    }
}
