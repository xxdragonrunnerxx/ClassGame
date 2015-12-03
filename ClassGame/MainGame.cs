/***********************************************************
  * Bradley Massey
  * 9/6/2015
  * C#
  * MainGame
  * 
  * 
  * Play(playerClass p, board[] b, int f)
  * WIN()
  * endGame()
  * clearScreen()
  ***********************************************************/
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
        //variable
        public static int floor { get; set; }
        //main game
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
                if (presentMap.town)
                {

                }
                else
                {
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
                }
            } while (cki.Key != ConsoleKey.Escape);
            Program.Save(character, gameMaps, f);
            endGame();
        }
        //winning screen
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
        //loosing screen
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
        //clears screen
        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
