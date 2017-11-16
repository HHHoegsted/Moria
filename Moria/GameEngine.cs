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
        public Item key;
        public Item healthPotion;
        public Room currentRoom;
        public Room startingRoom;
        public Room potionRoom;
        public Room bedRoom;
        public Room mobRoom;
        public Room trapRoom;


        public void StartGame()
        {
            string name;
            Console.WriteLine(Text.Splash);
            Console.WriteLine("Type help to see the commands");
            Console.WriteLine("What is your name, traveller?");
            name = Console.ReadLine();
            InstantiateObjects(name);
            CreateRelations();
            currentRoom = startingRoom;
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

                // Going east
                if (command.Equals("e"))
                {                    
                    if (currentRoom.status == "LockedEast" && currentRoom.neighbourEast != null)
                    {
                        Console.WriteLine("The next door is locked");
                        if (player1.HasItem(key))
                        {
                            Console.WriteLine("You have a key");
                            currentRoom.status = "";
                            changeRoom(currentRoom.neighbourEast);
                        }
                        
                    }
                    else if (currentRoom.status == "mob")
                    {
                        Console.WriteLine("you can't leave, a mob is fighting you!");
                    }
                    else if (currentRoom.neighbourEast != null)
                    {
                        changeRoom(currentRoom.neighbourEast);
                    }
                    else
                        Console.WriteLine("No rooms to the east!");
                }
                // Going west
                else if (command.Equals("w"))
                {
                    if (currentRoom.status == "LockedWest" && currentRoom.neighbourWest != null)
                    {
                        Console.WriteLine("The next door is locked");
                        if (player1.HasItem(key))
                        {
                            Console.WriteLine("You have a key");
                            currentRoom.status = "";
                            currentRoom.description = "You are standing in a room with a table and a door, which you have unlocked";
                            changeRoom(currentRoom.neighbourWest);
                        }
                    }
                    else if (currentRoom.status == "mob")
                    {
                        Console.WriteLine("You can't leave, a mob is fighting you!");
                    }
                    else if (currentRoom.neighbourWest != null)
                    {
                        changeRoom(currentRoom.neighbourWest);
                    }
                    else
                        Console.WriteLine("No rooms to the west!");
                }
                // Looking for help
                else if (command.Equals("help"))
                {
                    Console.WriteLine(Text.HelpText);
                }
                // Fight
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
                        currentRoom.status = "treasure";
                        mobRoom.description = Text.DeadTrollDescription;
                    }
                    
                }
                // Search the room
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
                            player1.itemList.Add(currentRoom.item);
                            Console.WriteLine("You picked up {0}", currentRoom.item.name);
                            currentRoom.item = null;
                        }
                    } else
                    {
                        Console.WriteLine("You find no items");
                    }

                    if (currentRoom.goldAmount > 0)
                    {
                        Console.WriteLine("You pick up {0} gold pieces", currentRoom.goldAmount);
                        player1.gold += currentRoom.goldAmount;
                        currentRoom.goldAmount = 0;
                    }
                }
                else if (command.Equals("inventory"))
                {
                    Console.WriteLine("You have picked up the following items :");
                    foreach (Item i in player1.itemList)
                    {
                        Console.WriteLine(i.name);
                    }
                    Console.WriteLine("and {0} pieces of gold", player1.gold);
                }
                // Quit the game
                else if (command.Equals("quit"))
                {
                    break;
                }
                // Unknown command
                else
                {
                    Console.WriteLine("I don't understand!");
                }

               

                if (player1.HasItem(healthPotion) && player1.life < 100)
                {
                    Console.WriteLine("You have lost health and you have a health potion");
                    Console.WriteLine("Do you wish to use it?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        player1.life = 100;
                        player1.UseItem(healthPotion);
                    }
                    
                }

                if (player1.HasItem(key))
                {
                    startingRoom.description = Text.startingRoomItemCollected;
                }
            }
        }

        private void CreateRelations()
        {
            startingRoom.neighbourWest = potionRoom;
            startingRoom.neighbourEast = bedRoom;
            potionRoom.neighbourEast = startingRoom;
            potionRoom.neighbourWest = mobRoom;
            bedRoom.neighbourWest = startingRoom;
            bedRoom.neighbourEast = trapRoom;
            mobRoom.neighbourEast = potionRoom;
            trapRoom.neighbourWest = bedRoom;

        }

        private void changeRoom(Room neighbour)
        {
            currentRoom = neighbour;
            Console.Clear();
            Console.WriteLine(Text.Splash);
            currentRoom.ShowDescription();
        }

        public void InstantiateObjects(string playerName)
        {
            player1 = new Player(playerName, 100);

            troll = new Mob("Troll", 50);

            key = new Item("a key");
            healthPotion = new Item("a health potion");
            

            startingRoom = new Room("Entrance", Text.startingRoomDescription);
            startingRoom.item = key;

            potionRoom = new Room("Left", Text.LeftRoomDescription);
            potionRoom.item = healthPotion;
            potionRoom.status = "LockedWest";
            potionRoom.goldAmount = 10;

            bedRoom = new Room("Right", Text.RightRoomDescription);
            bedRoom.goldAmount = 20;

            mobRoom = new Room("Far Left", Text.LeftLeftRoomDescription);
            mobRoom.status = "mob";
            mobRoom.goldAmount = 500;

            trapRoom = new Room("Far Right", Text.RightRightRoomDescription);
            trapRoom.status = "trap";

        }
    }
}
