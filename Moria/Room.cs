using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class Room
    {
        public string location;
        public string description;

        public Room(string aName, string aDescription)
        {
            location = aName;
            description = aDescription;
        }
    }
}
