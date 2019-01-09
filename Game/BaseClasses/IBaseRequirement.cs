using AdministratorProject.Game.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministratorProject.Game.BaseClasses
{
    public abstract class IBaseRequirement
    {
        public abstract float IsSatisfied(CCultivator c);
        public string Description { get; set; }

    }

}
