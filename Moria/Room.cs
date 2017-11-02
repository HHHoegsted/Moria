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
        public Item item;
        public Room neighbourRight;
        public Room neighbourLeft;
        public bool collectedItem;
        public string status;

        public Room(string aName, string aDescription)
        {
            location = aName;
            description = aDescription;
            collectedItem = false;
        }

        public void ShowDescription()
        {
            Console.WriteLine(this.description);
        }
    }
}
