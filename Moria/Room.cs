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
        int amountOfGold;
        string Item;

        public Room(string aLocation)
        {
            location = aLocation;
        }
    }
}
