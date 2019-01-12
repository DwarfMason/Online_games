using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApplication1.Game.BaseClasses;

namespace WebApplication1.Game.UpdateClasses.NPC
{
    public class CNPC:CLocation
    {
        public string Portret;
        public CNPC(GInt gInt, string name, int? p, string portret) : base(gInt, name,p)
        {
            Portret = portret;
            //todo Хз что но можно
        }
    }
}
