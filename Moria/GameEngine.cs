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
        public Room currentRoom;
        public Room middleRoom;
        public Room leftRoom;
        public Room rightRoom;

        public void StartGame()
        {
            Console.WriteLine("The Game has begun!");
            InstantiateObjects();
            CreateRelations();
            currentRoom = middleRoom;
            startGameLoop();
        }

        private void startGameLoop()
        {
            string command;

            currentRoom.ShowDescription();

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                command = Console.ReadLine().ToLower();

                if (command.Equals("r"))
                {
                    //GO RIGHT!!
                    if (currentRoom.neighbourRight != null)
                    {
                        currentRoom = currentRoom.neighbourRight;
                        currentRoom.ShowDescription();
                    }
                    else
                        Console.WriteLine("No rooms to the right!");
                }
                else if (command.Equals("l"))
                {
                    //GO LEFT!!
                    if (currentRoom.neighbourLeft != null)
                    {
                        currentRoom = currentRoom.neighbourLeft;
                        currentRoom.ShowDescription();
                    }
                    else
                        Console.WriteLine("No rooms to the left!");
                }
                else if (command.Equals("help"))
                {
                    Console.WriteLine("Press R for Right and L for Left and Quit to quit the game");
                }
                else if (command.Equals("quit"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("I don't understand!");
                }
            }
        }

        private void CreateRelations()
        {
            middleRoom.neighbourLeft = leftRoom;
            middleRoom.neighbourRight = rightRoom;
            leftRoom.neighbourRight = middleRoom;
            rightRoom.neighbourLeft = middleRoom;
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
