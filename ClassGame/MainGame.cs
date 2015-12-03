using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassGame
{
    class MainGame
    {

        public static int floor { get; set; }
        public static void Play(playerClass p, board[] b, int f)
        {

            floor = f;
            clearScreen();
            gameSave save;
            playerClass character = p;
            board[] gameMaps = b;
            ConsoleKeyInfo cki;

            do
            {
                if(f>gameMaps.Length-1)
                {
                    WIN();
                    break;
                }
                
                board presentMap = gameMaps[f];
                Console.SetCursorPosition(0, 0);
                presentMap.printBoard();
                int[] player = presentMap.playerLocation();
                int x = player[0];
                int y = player[1];
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow)
                    presentMap.moveUP(x, y);
                else if (cki.Key == ConsoleKey.DownArrow)
                    presentMap.moveDOWN(x, y);
                else if (cki.Key == ConsoleKey.LeftArrow)
                    presentMap.moveLEFT(x, y);
                else if (cki.Key == ConsoleKey.RightArrow)
                    presentMap.moveRIGHT(x, y);
                if (presentMap.checkStairs(x, y))
                {
                    f++;
                    clearScreen();
                }
                if (cki.Key == ConsoleKey.Enter)
                {
                    f++;
                    clearScreen();
                }
            } while (cki.Key != ConsoleKey.Escape);
            Program.Save(character, gameMaps, f);
            endGame();
        }
        public static void WIN()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄  ");
            Console.WriteLine("▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░▌ ");
            Console.WriteLine(" ▀▀▀▀█░█▀▀▀▀ ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀█░▌");
            Console.WriteLine("     ▐░▌     ▐░▌       ▐░▌▐░▌               ▐░▌          ▐░▌▐░▌    ▐░▌▐░▌       ▐░▌");
            Console.WriteLine("     ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌ ▐░▌   ▐░▌▐░▌       ▐░▌");
            Console.WriteLine("     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌  ▐░▌  ▐░▌▐░▌       ▐░▌");
            Console.WriteLine("     ▐░▌     ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌   ▐░▌ ▐░▌▐░▌       ▐░▌");
            Console.WriteLine("     ▐░▌     ▐░▌       ▐░▌▐░▌               ▐░▌          ▐░▌    ▐░▌▐░▌▐░▌       ▐░▌");
            Console.WriteLine("     ▐░▌     ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌     ▐░▐░▌▐░█▄▄▄▄▄▄▄█░▌");
            Console.WriteLine("     ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░░░░░░░░░░▌ ");
            Console.WriteLine("      ▀       ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀▀▀▀▀▀▀▀▀▀  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void endGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ▄▀▀▀▀▄    ▄▀▀█▄   ▄▀▀▄ ▄▀▄  ▄▀▀█▄▄▄▄      ▄▀▀▀▀▄   ▄▀▀▄ ▄▀▀▄  ▄▀▀█▄▄▄▄  ▄▀▀▄▀▀▀▄  ");
            Console.WriteLine(" █         ▐ ▄▀ ▀▄ █  █ ▀  █ ▐  ▄▀   ▐     █      █ █   █    █ ▐  ▄▀   ▐ █   █   █ ");
            Console.WriteLine(" █    ▀▄▄    █▄▄▄█ ▐  █    █   █▄▄▄▄▄      █      █ ▐  █    █    █▄▄▄▄▄  ▐  █▀▀█▀  ");
            Console.WriteLine(" █     █ █  ▄▀   █   █    █    █    ▌      ▀▄    ▄▀    █   ▄▀    █    ▌   ▄▀    █  ");
            Console.WriteLine(" ▐▀▄▄▄▄▀ ▐ █   ▄▀  ▄▀   ▄▀    ▄▀▄▄▄▄         ▀▀▀▀       ▀▄▀     ▄▀▄▄▄▄   █     █   ");
            Console.WriteLine(" ▐         ▐   ▐   █    █     █    ▐                            █    ▐   ▐     ▐   ");
            Console.WriteLine("                   ▐    ▐     ▐                                 ▐                  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
