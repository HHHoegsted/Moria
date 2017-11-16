using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class Room

    {
        enum stat { none, mob, trap, lockedwest, lockedeast}
        public string location;
        public string description;
        public Item item;
        public int goldAmount;
        public Room neighbourEast;
        public Room neighbourWest;
        public string status;

        public Room(string aName, string aDescription)
        {
            location = aName;
            description = aDescription;
        }

        public void ShowDescription()
        {
            Console.WriteLine(this.description);
        }
    }
}
