﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministratorProject.Game.BaseClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdministratorProject.Game.UpdateClasses.NPC
{
    public class CNPC:CLocation
    {
        public CNPC(GInt gInt, string name, int? p) : base(gInt, name,p)
        {
            //todo Хз что но можно
        }
    }
}