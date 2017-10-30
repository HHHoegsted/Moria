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

        public int AmountOfGold { get => amountOfGold; private set => amountOfGold = value; }

        public void setNeighbour(string direction, string aLocation)
        {
            switch (direction)
            {
                case "north":
                    neighbourNorth.location = aLocation;
                    break;
                case "south":
                    neighbourSouth.location = aLocation;
                    break;
                case "east":
                    neighbourEast.location = aLocation;
                    break;
                case "west":
                    neighbourWest.location = aLocation;
                    break;
            }

        }
    }
}
