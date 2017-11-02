using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class GameEngine
    {
        public Player player1;
        public Item item1;
        public Room middleRoom;
        public Room leftRoom;
        public Room rightRoom;

        public void StartGame()
        {
            Console.WriteLine("The Game has begun!");
            InstantiateObjects();
        }

        public void InstantiateObjects()
        {
            player1 = new Player("HH", 100);
            item1 = new Item("Key");
            middleRoom = new Room("Middle", "Starting Room");
            leftRoom = new Room("Left", "Left Room");
            rightRoom = new Room("Right", "Right Room");
        }
    }
}
