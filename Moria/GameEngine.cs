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
        public Room leftLeftRoom;

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
                    if (currentRoom.status == "LockedRight" && currentRoom.neighbourRight != null)
                    {
                        Console.WriteLine("The next door is locked");
                        if (middleRoom.collectedItem)
                        {
                            Console.WriteLine("You have a key");
                            currentRoom.status = "";
                            currentRoom = currentRoom.neighbourRight;
                            currentRoom.ShowDescription();
                        }
                        
                    }
                    else if (currentRoom.neighbourRight != null)
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
                    if (currentRoom.status == "LockedLeft" && currentRoom.neighbourLeft != null)
                    {
                        Console.WriteLine("The next door is locked");
                        if (middleRoom.collectedItem)
                        {
                            Console.WriteLine("You have a key");
                            currentRoom.status = "";
                            currentRoom = currentRoom.neighbourLeft;
                            currentRoom.ShowDescription();
                        }
                    }
                    else if (currentRoom.neighbourLeft != null)
                    {
                        currentRoom = currentRoom.neighbourLeft;
                        currentRoom.ShowDescription();
                    }
                    else
                        Console.WriteLine("No rooms to the left!");
                }
                else if (command.Equals("help"))
                {
                    Console.WriteLine("R for Right \nL for Left \nSearch to search the room \nQuit to quit the game");
                }
                else if (command.Equals("quit"))
                {
                    break;
                }
                else if (command.Equals("search"))
                {
                    Console.WriteLine("You search the room");
                    if (currentRoom.item != null)
                    {
                        Console.WriteLine("You find an item, it is {0}", currentRoom.item.name);
                        Console.WriteLine("do you want to pick it up?");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes")
                        {
                            currentRoom.collectedItem = true;
                            Console.WriteLine("You picked up {0}", currentRoom.item.name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You find nothing");
                    }
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
            leftRoom.neighbourLeft = leftLeftRoom;
            rightRoom.neighbourLeft = middleRoom;
            leftLeftRoom.neighbourRight = leftRoom;

        }

        public void InstantiateObjects()
        {
            player1 = new Player("HH", 100);
            item1 = new Item("a key");
            middleRoom = new Room("Middle", "Starting Room");
            middleRoom.item = item1;
            leftRoom = new Room("Left", "Left Room, the door to the left is locked");
            leftRoom.status = "LockedLeft";
            rightRoom = new Room("Right", "Right Room");
            leftLeftRoom = new Room("Far Left", "Left room behind a locked door");

        }
    }
}
