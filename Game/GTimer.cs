﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using WebApplication1.Game;

namespace WebApplication1.Game
{
    public class GString
    {
        private static GString instance;
        private static object syncRoot = new Object();
        public string test;
        GString()
        {
            test = "abc";
        }
        public static GString GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new GString();
                }
            }
            return instance;
        }
        public class GTimer
        {
            private Timer timer;
           // private CWorld World = GWorld.World; todo

        }
    }
}
