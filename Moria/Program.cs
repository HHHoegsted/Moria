﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moria
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine game = new GameEngine();
            game.StartGame();
            Console.WriteLine("\n\nThe game has ended. Thank you for playing");
            Console.ReadKey();
        }
    }
}
