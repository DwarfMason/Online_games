using AdministratorProject.Game.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministratorProject.Game.BaseClasses
{
    public abstract class IBaseActions
    {
        public string Description { get; set; }
        public List<IBaseRequirement> Requirements { get; set; }

        public float CanDo(CCultivator c)
        {
            float _out = 1;
            foreach (var i in Requirements)
            {
                _out *= i.IsSatisfied(c);
            }
            return _out;
        }

        abstract public void Do(CCultivator c);

    }
}
