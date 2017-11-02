using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class Mob
    {
        public string name;
        public int life;

        public Mob(string aName, int lifeAmount)
        {
            name = aName;
            life = lifeAmount;
        }
    }
}
