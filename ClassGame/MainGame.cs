using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class MainGame
    {
        public static void Play(playerClass p, board[] b, int f)
        {
            clearScreen();
            gameSave save;
            playerClass character = p;
            int floor = f;
            board[] gameMaps = b;
            ConsoleKeyInfo cki;
            
            do
            {
                board presentMap = gameMaps[f];
                Console.SetCursorPosition(0, 0);
                presentMap.printBoard();
                int[] player = presentMap.playerLocation();
                int x = player[0];
                int y = player[1];
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow)
                    presentMap.moveUP(x, y);
                if (cki.Key == ConsoleKey.DownArrow)
                    presentMap.moveDOWN(x, y);
                if (cki.Key == ConsoleKey.LeftArrow)
                    presentMap.moveLEFT(x, y);
                if (cki.Key == ConsoleKey.RightArrow)
                    presentMap.moveRIGHT(x, y);
                if (presentMap.checkStairs(x, y))
                    f++;
            } while (cki.Key != ConsoleKey.Escape);
        }
        public static void clearScreen()
        {
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x < 400; x++) 
            {
                for (int y = 0; y < 400; y++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
