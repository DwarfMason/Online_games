using WebApplication1.Game.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Game.BaseClasses
{
    public abstract class IBaseRequirement
    {
        public abstract float IsSatisfied(CCultivator c);
        public string Description { get; set; }

    }

}
