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

        private Room neighbourNorth;
        private Room neighbourSouth;
        private Room neighbourEast;
        private Room neighbourWest;

        public Room(string aLocation)
        {
            location = aLocation;
        }
    }
}
