/***********************************************************
  * Bradley Massey
  * 12/3/2015
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
                if (f > gameMaps.Length - 1)
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
                
                if (presentMap.town)
                {
                    Console.WriteLine("Where would you like to go?");
                    Console.Write("(G)eneral Store, (A)rmory, (O)ut of Town:");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.G)
                    {
                        //run general store
                        clearScreen();
                    }
                    else if (cki.Key == ConsoleKey.A)
                    {
                        //run armory
                        clearScreen();
                    }
                    else if (cki.Key == ConsoleKey.O)
                    {
                        f++;
                        clearScreen();
                    }
                }
                else
                {
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
            Console.ReadLine();
        }
        //loosing screen
        public static void endGame()
        {
            clearScreen();
            int pauseTime = 200;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ▄▀▀▀▀▄    ▄▀▀█▄   ▄▀▀▄ ▄▀▄  ▄▀▀█▄▄▄▄      ▄▀▀▀▀▄   ▄▀▀▄ ▄▀▀▄  ▄▀▀█▄▄▄▄  ▄▀▀▄▀▀▀▄  ");
            System.Threading.Thread.Sleep(pauseTime);
            Console.WriteLine(" █         ▐ ▄▀ ▀▄ █  █ ▀  █ ▐  ▄▀   ▐     █      █ █   █    █ ▐  ▄▀   ▐ █   █   █ ");
            System.Threading.Thread.Sleep(pauseTime);
            Console.WriteLine(" █    ▀▄▄    █▄▄▄█ ▐  █    █   █▄▄▄▄▄      █      █ ▐  █    █    █▄▄▄▄▄  ▐  █▀▀█▀  ");
            System.Threading.Thread.Sleep(pauseTime);
            Console.WriteLine(" █     █ █  ▄▀   █   █    █    █    ▌      ▀▄    ▄▀    █   ▄▀    █    ▌   ▄▀    █  ");
            System.Threading.Thread.Sleep(pauseTime);
            Console.WriteLine(" ▐▀▄▄▄▄▀ ▐ █   ▄▀  ▄▀   ▄▀    ▄▀▄▄▄▄         ▀▀▀▀       ▀▄▀     ▄▀▄▄▄▄   █     █   ");
            System.Threading.Thread.Sleep(pauseTime);
            Console.WriteLine(" ▐         ▐   ▐   █    █     █    ▐                            █    ▐   ▐     ▐   ");
            System.Threading.Thread.Sleep(pauseTime);
            Console.WriteLine("                   ▐    ▐     ▐                                 ▐                  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
        //clears screen
        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
