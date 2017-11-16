using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class Text
    {
        public static string Splash = @"
 ███▄ ▄███▓ ▒█████   ██▀███   ██▓ ▄▄▄          ███▄ ▄███▓ ██▓ ███▄    █ ▓█████   ██████  ▐██▌ 
▓██▒▀█▀ ██▒▒██▒  ██▒▓██ ▒ ██▒▓██▒▒████▄       ▓██▒▀█▀ ██▒▓██▒ ██ ▀█   █ ▓█   ▀ ▒██    ▒  ▐██▌ 
▓██    ▓██░▒██░  ██▒▓██ ░▄█ ▒▒██▒▒██  ▀█▄     ▓██    ▓██░▒██▒▓██  ▀█ ██▒▒███   ░ ▓██▄    ▐██▌ 
▒██    ▒██ ▒██   ██░▒██▀▀█▄  ░██░░██▄▄▄▄██    ▒██    ▒██ ░██░▓██▒  ▐▌██▒▒▓█  ▄   ▒   ██▒ ▓██▒ 
▒██▒   ░██▒░ ████▓▒░░██▓ ▒██▒░██░ ▓█   ▓██▒   ▒██▒   ░██▒░██░▒██░   ▓██░░▒████▒▒██████▒▒ ▒▄▄  
░ ▒░   ░  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░▓   ▒▒   ▓▒█░   ░ ▒░   ░  ░░▓  ░ ▒░   ▒ ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░ ░▀▀▒ 
░  ░      ░  ░ ▒ ▒░   ░▒ ░ ▒░ ▒ ░  ▒   ▒▒ ░   ░  ░      ░ ▒ ░░ ░░   ░ ▒░ ░ ░  ░░ ░▒  ░ ░ ░  ░ 
░      ░   ░ ░ ░ ▒    ░░   ░  ▒ ░  ░   ▒      ░      ░    ▒ ░   ░   ░ ░    ░   ░  ░  ░      ░ 
       ░       ░ ░     ░      ░        ░  ░          ░    ░           ░    ░  ░      ░   ░    
                                                                                              
";

        public static string HelpText = @"E for East
W for West
Search to search the room
Fight to fight
Quit to quit the game";

        public static string startingRoomDescription = @"You have entered a damp tunnel. Torches are flickering and you catch a glimmer on the floor.
The tunnel leads off to both the left and the right";
        public static string startingRoomItemCollected = @"You are in a damp tunnel. Torches are flickering.
The tunnel leads off to both the left and the right";

        public static string LeftRoomDescription = @"The tunnel to the left is blocked by a heavy door, which is locked. 
You can hear heavy breathing behind the locked door.

Standing on a table besides the door is a collection of vials and flasks.

The tunnel to the right leads back through the tunnel.";

        public static string RightRoomDescription = @"The tunnel opens up into a big room. There is a bed which hasn't been used for quite a while.

On the far right of the room the tunnel continues, and on the left of the room the tunnel goes back through the tunnel";

        public static string LeftLeftRoomDescription = @"As you open the door a giant troll charges towards you with a club.
Behind the troll you see a chest, and behind you to the right the door is open.";

        public static string DeadTrollDescription = @"The troll lies dead on the floor.
Behind the troll you see a chest, and behind you to the right the door is open.";

        public static string RightRightRoomDescription = @"Stones fall from the tunnel and onto you. You are seriously hurt.

The tunnel in front of you is now collapsed and behind you to the left is the room with a bed.";


    }
}
