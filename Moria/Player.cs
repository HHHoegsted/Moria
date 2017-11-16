using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class Player
    {
        public string name;
        public int life;
        public List<Item> itemList = new List<Item>();
        public int gold;

        public Player(string aName, int lifeAmount)
        {
            name = aName;
            life = lifeAmount;
            gold = 0;
        }
        public bool HasItem(Item item)
        {
            foreach (Item i in this.itemList)
            {
                if (i.name == item.name)
                    return true;
            }
            return false;
        }

        public void UseItem(Item item)
        {
            this.itemList.Remove(item);
        }
    }
}
