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
        public Mob troll;
        public Item item1;
        public Item item2;
        public Room currentRoom;
        public Room middleRoom;
        public Room leftRoom;
        public Room rightRoom;
        public Room leftLeftRoom;
        public Room rightRightRoom;


        public void StartGame()
        {
            Console.WriteLine("The Game has begun!");
            Console.WriteLine("Type help to see the commands");
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
                    else if (currentRoom.status == "mob")
                    {
                        Console.WriteLine("you can't leave, a mob is fighting you!");
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
                            currentRoom.description = "Left room, the door to the left is unlocked.";
                            currentRoom = currentRoom.neighbourLeft;
                            currentRoom.ShowDescription();
                        }
                    }
                    else if (currentRoom.status == "mob")
                    {
                        Console.WriteLine("You can't leave, a mob is fighting you!");
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
                    Console.WriteLine("R for Right \nL for Left \nSearch to search the room \nFight to fight \nQuit to quit the game");
                }
                else if (command.Equals("quit"))
                {
                    break;
                }
                else if (command.Equals("fight"))
                {
                    while (troll.life > 0 && player1.life > 0)
                    {
                        Console.WriteLine("The troll hits you, and you fight back");
                        player1.life -= 10;
                        troll.life -= 20;
                        Console.WriteLine("your health is {0} and the trolls' health is {1}", player1.life, troll.life);
                    }

                    if (player1.life <= 0)
                    {
                        Console.WriteLine("You are dead, game is over");
                        Console.ReadKey();
                        break;
                    }

                    if (troll.life <= 0)
                    {
                        Console.WriteLine("You are victorious and the troll is dead");
                        currentRoom.status = "";
                        leftLeftRoom.description = "The far left room, there is a dead troll on the floor";
                    }
                    
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
                            currentRoom.item = null;
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

                if (currentRoom.status == "trap")
                {
                    player1.life -= 80;
                    if (player1.life <= 0)
                    {
                        Console.WriteLine("You have died from the trap");
                        Console.WriteLine("The game is over");
                        break;
                    }
                    currentRoom.status = "";
                }

                if (leftRoom.collectedItem && player1.life < 100)
                {
                    Console.WriteLine("You have lost health and you have a health potion");
                    Console.WriteLine("Do you wish to use it?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        player1.life = 100;
                        leftRoom.collectedItem = false;
                    }
                    
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
            rightRoom.neighbourRight = rightRightRoom;
            leftLeftRoom.neighbourRight = leftRoom;
            rightRightRoom.neighbourLeft = rightRoom;

        }

        public void InstantiateObjects()
        {
            player1 = new Player("HH", 100);
            troll = new Mob("Troll", 50);
            item1 = new Item("a key");
            item2 = new Item("a health potion");
            middleRoom = new Room("Middle", "Starting Room\nThere are exits to the left and right");
            middleRoom.item = item1;
            leftRoom = new Room("Left", "Left Room\nThere are exits to the left and right\nThe left door is locked");
            leftRoom.item = item2;
            leftRoom.status = "LockedLeft";
            rightRoom = new Room("Right", "Right Room\nThere are exits to the left and right");
            leftLeftRoom = new Room("Far Left", "There is an exit to the right\nBehind the locked door is a troll, and it attacks you!");
            leftLeftRoom.status = "mob";
            rightRightRoom = new Room("Far Right", "There is an exit to the left\nYou stumble upon a trap");
            rightRightRoom.status = "trap";

        }
    }
}
