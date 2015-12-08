/***********************************************************
  * Bradley Massey
  * 12/3/2015
  * C#
  * Board
  * 
  * 
  *
  * board(int x)
  * board(int x, int y)
  * board(int x, int y,int buildings)
  * inverseFloor(int lenght, int width)
  * playerLocation()
  * printBoard()
  * newRoom()
  * newBuilding(int b)
  * corridor()
  * exit(int turns)
  * setFloor(int x, int y)
  * setWildernessFloor(int x, int y)
  * setSidewalk(int x, int y)
  * setBuilding(int x, int y)
  * checkBuilding(int l, int w, int x, int y)
  * makeBuilding(int l, int w, int x, int y,int building)
  * checkRoom(int l, int w, int x, int y)
  * makeRoom(int l, int w, int x, int y)
  * createWilderness(int d)
  * setStairs()
  * setStairs(bool town)
  * setPlayer()
  * setPlayer(int location)
  * setDoors(int x, int y)
  * checkOddRoom(int s, int o, int x, int y)
  * makeOddRoom(int s, int o, int x, int y)
  * checkStairs(int x, int y)
  * moveDOWN(int x, int y)
  * moveUP(int x, int y)
  * moveRIGHT(int x, int y)
  * moveLEFT(int x, int y)
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class board
    {
        //variables
        private tile[,] gameBoard;
        public int length= dieroller.totalRoll(10, 20);
        public int width=dieroller.totalRoll(10, 10);
        public static int rooms = 15;
        public int counts = 0;
        public int[,] Center = new int[rooms, 2];
        public int[,] Doors;
        public bool town = false;
        public string story { get; set; }
        
        //creates wilderness
        public board(int x)
        {
            gameBoard = new tile[length, width];
            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    gameBoard[a, b] = new tile(" ", ConsoleColor.Blue, ConsoleColor.DarkGreen, true);
                }
            }
            createWilderness(x);
            exit(30);
        }
        //creates board
        public board(int x, int y)
        {
            gameBoard = new tile[x, y];
            length = x;
            width = y;

            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    gameBoard[a, b] = new tile("#", ConsoleColor.Black, ConsoleColor.Red, true);
                }
            }
            for (int a = 1; a < length - 1; a++)
            {
                for (int b = 1; b < width - 1; b++)
                {
                    gameBoard[a, b].ForegroundColor = ConsoleColor.DarkGray;
                    gameBoard[a, b].BackgroundColor = ConsoleColor.Black;
                }
            }
            for (int count = 0; count < rooms; count++)
            {
                newRoom();
            }
            setStairs();
            setPlayer();
            corridor();
         }
        //creates town
        public board(int x, int y,int buildings)
        {
            Doors = new int[buildings, 2];
            town = true;
            gameBoard = new tile[x, y];
            length = x;
            width = y;

            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    gameBoard[a, b] = new tile("#", ConsoleColor.Black, ConsoleColor.Red, true);
                }
            }
            for (int a = 1; a < length - 1; a++)
            {
                for (int b = 1; b < width - 1; b++)
                {
                    gameBoard[a, b].wall = false;
                    gameBoard[a, b].ForegroundColor = ConsoleColor.DarkGray;
                    gameBoard[a, b].BackgroundColor = ConsoleColor.Black;
                }
            }
            for (int count = 0; count < buildings; count++)
            {
                newBuilding(count);
            }
            inverseFloor(length, width);
        }
        //sets buildings
        private void inverseFloor(int lenght, int width)
        {
            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    if (gameBoard[a, b].symbol.CompareTo("#") != 0)
                        setBuilding(a, b);
                    else
                        setSidewalk(a, b);

                }
            }
        }
        public int[] playerLocation()
        {
            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    if (gameBoard[a, b].playerHere)
                    {
                        int[] player = { a, b };
                        return player;
                    }
                }
            }
            int[] x = { 0, 0 };
            return x;
        }
        //prints board
        public void printBoard()
        {
            int[] player = playerLocation();
            int x = player[0];
            int y = player[1];
            int startx = x - 3;
            int starty = y - 5;
            int endx = x + 3;
            int endy = y + 5;
            if (town)
            {
                for (int a = 0; a < length; a++)
                {
                    for (int b = 0; b < width; b++)
                    {
                        if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere || gameBoard[a, b].door)
                        {
                            if (gameBoard[a, b].playerHere)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write("@");
                            }
                            else if (gameBoard[a, b].stairsHere)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                Console.Write(">");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("†");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            Console.Write(gameBoard[a, b].symbol);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("");
                }
            }
            else
            {
                if (startx >= 0 && starty >= 0 && endx <= length && endy <= width)
                {
                    for (int a = startx; a < endx; a++)
                    {
                        for (int b = starty; b < endy; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a, b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx < 0 && starty >= 0 && endx <= length && endy <= width)
                {
                    for (int a = 0; a < 6; a++)
                    {
                        for (int b = starty; b < endy; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a, b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx < 0 && starty < 0 && endx <= length && endy <= width)
                {
                    for (int a = 0; a < 6; a++)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a , b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx >= 0 && starty < 0 && endx <= length && endy <= width)
                {
                    for (int a = startx; a < endx; a++)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a, b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx >= 0 && starty >= 0 && endx > length && endy <= width)
                {
                    for (int a = length - 6; a < length; a++)
                    {
                        for (int b = starty; b < endy; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a, b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx >= 0 && starty >= 0 && endx <= length && endy > width)
                {
                    for (int a = startx; a < endx; a++)
                    {
                        for (int b = width - 10; b < width; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a , b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx > 0 && starty > 0 && endx > length && endy > width)
                {
                    for (int a = length - 6; a < length; a++)
                    {
                        for (int b = width - 10; b < width; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a , b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx >= 0 && starty < 0 && endx > length && endy <= width)
                {
                    for (int a = length - 6; a < length; a++)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a , b);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b );
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
                else if (startx < 0 && starty >= 0 && endx <= length && endy > width)
                {
                    for (int a = 0; a < 6; a++)
                    {
                        for (int b = width - 10; b < width; b++)
                        {
                            if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                            {
                                if (gameBoard[a, b].playerHere)
                                {
                                    Console.SetCursorPosition(a , b );
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("@");
                                }
                                else
                                {
                                    Console.SetCursorPosition(a, b);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("‡");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(a , b);
                                Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                                Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                                Console.Write(gameBoard[a, b].symbol);
                            }
                            //    if (gameBoard[a, b].playerHere)
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            //        Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //        Console.Write("@@");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("@@");
                            //    }
                            //    else
                            //    {
                            //        Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //        Console.ForegroundColor = ConsoleColor.Red;
                            //        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            //        Console.Write("‡‡");
                            //        Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //        Console.Write("‡‡");
                            //    }
                            //}
                            //else
                            //{
                            //    Console.SetCursorPosition(a + (a * 2), b + (b * 2));
                            //    Console.ForegroundColor = gameBoard[a, b].ForegroundColor;
                            //    Console.BackgroundColor = gameBoard[a, b].BackgroundColor;
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //    Console.SetCursorPosition(a + (a * 2), b + 1 + (b * 2));
                            //    Console.Write(gameBoard[a, b].symbol + gameBoard[a, b].symbol);
                            //}
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("");
                    }
                }
            }
        }

        //creates new room
        private void newRoom()
        {
            int x = dieroller.totalRoll(1, length);
            int y = dieroller.totalRoll(1, width);
            int h = dieroller.totalRoll(3, 5);
            int w = dieroller.totalRoll(3, 5);
            int odd = dieroller.totalRoll(1, 50);
            if (odd < 30)
            {
                if (checkRoom(h, w, x, y))
                {
                    Center[counts, 0] = x + (h / 2);
                    Center[counts, 1] = y + (w / 2);
                    counts++;
                    makeRoom(h, w, x, y);
                }
                else
                    newRoom();
            }
            else
            {
                if (checkOddRoom(h, odd, x, y))
                {
                    Center[counts, 0] = x + (h / 2);
                    Center[counts, 1] = y + (h / 2);
                    counts++;
                    makeOddRoom(h, odd, x, y);
                }
                else
                    newRoom();
            }

        }
        //creates a new building
        private void newBuilding(int b)
        {
            int x = dieroller.totalRoll(1, length);
            int y = dieroller.totalRoll(1, width);
            int h = dieroller.totalRoll(3, 5);
            int w = dieroller.totalRoll(3, 5);
            if (checkBuilding(h, w, x, y))
            {
                counts++;
                makeBuilding(h, w, x, y, b);
            }
            else
                newBuilding(b);
        }
        //creates corridor between rooms
        private void corridor()
        {
            for (int a = 0; a < rooms - 1; a++)
            {
                int x = Center[a, 0];
                int y = Center[a, 1];
                int i = Center[a + 1, 0];
                int j = Center[a + 1, 1];
                if (x >= i && y >= j)
                {
                    for (int down = i; down <= x; down++)
                    {
                        setFloor(down, j);
                    }
                    for (int right = j; right <= y; right++)
                    {
                        setFloor(x, right);
                    }
                }
                else if (x >= i)
                {
                    for (int down = i; down <= x; down++)
                    {
                        setFloor(down, j);
                    }
                    for (int left = y; left <= j; left++)
                    {
                        setFloor(x, left);
                    }
                }
                else if (y >= j)
                {
                    for (int up = x; up <= i; up++)
                    {
                        setFloor(up, j);
                    }
                    for (int right = j; right <= y; right++)
                    {
                        setFloor(x, right);
                    }
                }
                else
                {
                    for (int up = x; up <= i; up++)
                    {
                        setFloor(up, j);
                    }
                    for (int left = y; left <= j; left++)
                    {
                        setFloor(x, left);
                    }
                }
            }
        }
        //creates path through wilderness
        private void exit(int turns)
        {
            counts = 0;
            int[,] WCenter = new int[turns, 2];
            for (int a = 0; a < turns-1; a++)
            {
                int x = dieroller.totalRoll(1, length-1);
                int y = dieroller.totalRoll(1, width-1);
                WCenter[counts, 0] = x ;
                WCenter[counts, 1] = y ;
                counts++;
            }
            WCenter[0, 0] = Center[0, 0];
            WCenter[0, 1] = Center[0, 1];
            WCenter[turns-1, 0] = Center[1, 0];
            WCenter[turns-1, 1] = Center[1, 1];
            for (int a = 0; a < turns-1; a++)
            {
                int x = WCenter[a, 0];
                int y = WCenter[a, 1];
                int i = WCenter[a + 1, 0];
                int j = WCenter[a + 1, 1];
                if (x >= i && y >= j)
                {
                    for (int down = i; down <= x; down++)
                    {
                        setWildernessFloor(down, j);
                    }
                    for (int right = j; right <= y; right++)
                    {
                        setWildernessFloor(x, right);
                    }
                }
                else if (x >= i)
                {
                    for (int down = i; down <= x; down++)
                    {
                        setWildernessFloor(down, j);
                    }
                    for (int left = y; left <= j; left++)
                    {
                        setWildernessFloor(x, left);
                    }
                }
                else if (y >= j)
                {
                    for (int up = x; up <= i; up++)
                    {
                        setWildernessFloor(up, j);
                    }
                    for (int right = j; right <= y; right++)
                    {
                        setWildernessFloor(x, right);
                    }
                }
                else
                {
                    for (int up = x; up <= i; up++)
                    {
                        setWildernessFloor(up, j);
                    }
                    for (int left = y; left <= j; left++)
                    {
                        setWildernessFloor(x, left);
                    }
                }
            }
        }
        //set floor for dungeon tile
        private void setFloor(int x, int y)
        {
            gameBoard[x, y].symbol = " ";
            gameBoard[x, y].wall = false;
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkRed;
        }
        //set wilderness floor tile
        private void setWildernessFloor(int x, int y)
        {
            gameBoard[x, y].symbol = " ";
            gameBoard[x, y].wall = false;
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkGreen;
        }
        //set town sidewalk tile
        private void setSidewalk(int x, int y)
        {
            gameBoard[x, y].wall = false;
            gameBoard[x, y].symbol = " ";
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkGreen;
        }
        //set town building tile
        private void setBuilding(int x, int y)
        {
            gameBoard[x, y].wall = true;
            gameBoard[x, y].symbol = "‡";
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkGreen;
        }
        //checks to see if can place a building 
        private bool checkBuilding(int l, int w, int x, int y)
        {
            x--;
            y--;
            int y1 = y;
            for (int a = 0; a <= l+2; a++)
            {
                for (int b = 0; b <= w+2; b++)
                {
                    if (x > length - 2 || y > width - 2)
                        return false;
                    if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                        return false;
                    y++;
                }
                y = y1;
                x++;
            }
            return true;
        }
        //makes new building
        private void makeBuilding(int l, int w, int x, int y,int building)
        {
            int y1 = y;
            int x1 = x;
            for (int a = 0; a <= l; a++)
            {
                for (int b = 0; b <= w; b++)
                {
                    setBuilding(x, y);
                    y++;
                }
                y = y1;
                x++;
            }
            Doors[building, 0] = (x1 + l);
            Doors[building, 1] = (y1 + (w / 2));
            setDoors(Doors[building, 0], Doors[building, 1]);
        }
        //checks to see if can place a room
        private bool checkRoom(int l, int w, int x, int y)
        {
            int y1 = y;
            for (int a = 0; a <= l; a++)
            {
                for (int b = 0; b <= w; b++)
                {
                    if (x > length - 2 || y > width - 2)
                        return false;
                    if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                        return false;
                    y++;
                }
                y = y1;
                x++;
            }
            return true;
        }
        //makes new room
        private void makeRoom(int l, int w, int x, int y)
        {
            int y1 = y;
            for (int a = 0; a <= l; a++)
            {
                for (int b = 0; b <= w; b++)
                {
                    setFloor(x, y);
                    y++;
                }
                y = y1;
                x++;
            }
        }
        //creates wilderness
        private void createWilderness(int d)
        {

            for (int a = 0; a <= length - 1; a++)
            {
                for (int b = 0; b <= width - 1; b++)
                {
                    int random = dieroller.totalRoll(1, 100);
                    if (random >= d)
                    {
                        gameBoard[a, b].symbol = ".";
                        gameBoard[a, b].wall = false;
                        gameBoard[a, b].ForegroundColor = ConsoleColor.Blue;
                        gameBoard[a, b].BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        gameBoard[a, b].symbol = "^";
                        gameBoard[a, b].ForegroundColor = ConsoleColor.DarkGreen;
                        gameBoard[a, b].BackgroundColor = ConsoleColor.Black;
                    }
                }
            }
            setStairs();
            setPlayer(dieroller.totalRoll(1, 6));
            exit(20);
        }
        //set stairs
        private void setStairs()
        {
            int x = StaticRandom.Instance.Next(1, length);
            int y = StaticRandom.Instance.Next(1, width);
            if (string.Compare(gameBoard[x, y].symbol, "#") != 0)
            {
                gameBoard[x, y].stairsHere = true;
                Center[0, 0] = x;
                Center[0, 1] = y;
            }
            else
                setStairs();
        }
        //set stairs for town
        private void setStairs(bool town)
        {
            int x = length-1;
            int y = width / 2;
            if (string.Compare(gameBoard[x, y].symbol, "#") != 0)
            {
                gameBoard[x, y].stairsHere = true;
                Center[0, 0] = x;
                Center[0, 1] = y;
            }
            else
                setStairs();
        }
        //set player
        private void setPlayer()
        {
            int x = StaticRandom.Instance.Next(1, length);
            int y = StaticRandom.Instance.Next(1, width);
            if (string.Compare(gameBoard[x, y].symbol, "#") != 0)
            {
                if (string.Compare(gameBoard[x, y].symbol, ">") != 0)
                {
                    if (string.Compare(gameBoard[x, y].symbol, "‡") != 0)
                    {
                        gameBoard[x, y].playerHere = true;
                        Center[1, 0] = x;
                        Center[1, 1] = y;
                    }
                    else
                        setPlayer();
                }
                else
                    setPlayer();
            }
            else
                setPlayer();
        }
        //set player in perticular location
        private void setPlayer(int location)
        {

            int x;
            int y;
            bool again = true;
            switch (location)
            {
                case 1:
                    x = 1;
                    y = 1;
                    do
                    {
                        if (x < length && string.Compare(gameBoard[x, y].symbol, "#") != 0)
                        {
                            if (x < length && string.Compare(gameBoard[x, y].symbol, ">") != 0)
                            {
                                gameBoard[x, y].playerHere = true;
                                Center[1, 0] = x;
                                Center[1, 1] = y;
                                again = false;
                            }
                            else
                                x++;
                        }
                        else
                            x++;
                    } while (x < length && again);
                    break;
                case 2:
                    x = 1;
                    y = 1;
                    do
                    {
                        if (y < width && string.Compare(gameBoard[x, y].symbol, "#") != 0)
                        {
                            if (y < width && string.Compare(gameBoard[x, y].symbol, ">") != 0)
                            {
                                gameBoard[x, y].playerHere = true;
                                Center[1, 0] = x;
                                Center[1, 1] = y;
                                again = false;
                            }
                            else
                                y++;
                        }
                        else
                            y++;
                    } while (y < width && again);
                    break;
                case 3:
                    x = 1;
                    y = width - 2;
                    do
                    {
                        if (x < length && string.Compare(gameBoard[x, y].symbol, "#") != 0)
                        {
                            if (x < length && string.Compare(gameBoard[x, y].symbol, ">") != 0)
                            {
                                gameBoard[x, y].playerHere = true;
                                Center[1, 0] = x;
                                Center[1, 1] = y;
                                again = false;
                            }
                            else
                                x++;
                        }
                        else
                            x++;
                    } while (x < length && again);
                    break;
                case 4:
                    x = length - 2;
                    y = 1;
                    do
                    {
                        if (y < width && string.Compare(gameBoard[x, y].symbol, "#") != 0)
                        {
                            if (y < width && string.Compare(gameBoard[x, y].symbol, ">") != 0)
                            {
                                gameBoard[x, y].playerHere = true;
                                Center[1, 0] = x;
                                Center[1, 1] = y;
                                again = false;
                            }
                            else
                                y++;
                        }
                        else
                            y++;
                    } while (y < width && again);
                    break;
                case 5:
                    x = length - 2;
                    y = width - 2;
                    do
                    {
                        if (y >= 1 && string.Compare(gameBoard[x, y].symbol, "#") != 0)
                        {
                            if (y >= 1 && string.Compare(gameBoard[x, y].symbol, ">") != 0)
                            {
                                gameBoard[x, y].playerHere = true;
                                Center[1, 0] = x;
                                Center[1, 1] = y;
                                again = false;
                            }
                            else
                                y--;
                        }
                        else
                            y--;
                    } while (y >= 1 && again);
                    break;
                default:
                    x = length - 2;
                    y = width - 2;
                    do
                    {
                        if (x >= 1 && string.Compare(gameBoard[x, y].symbol, "#") != 0)
                        {
                            if (x >= 1 && string.Compare(gameBoard[x, y].symbol, ">") != 0)
                            {
                                gameBoard[x, y].playerHere = true;
                                Center[1, 0] = x;
                                Center[1, 1] = y;
                                again = false;
                            }
                            else
                                x--;
                        }
                        else
                            x--;
                    } while (x >= 1 && again);
                    break;
            }
            if (again)
                setPlayer(dieroller.totalRoll(1, 6));
        }
        //sets door to building
        public void setDoors(int x, int y)
        {
            gameBoard[x, y].door = true;
        }
        // //checks to see if can place a odd shaped room
        private bool checkOddRoom(int s, int o, int x, int y)
        {
            int y1 = y;
            if (o < 35)
            {
                for (int a = 0; a <= s; a++)
                {
                    for (int b = 0; b <= a; b++)
                    {
                        if (x > length - 2 || y > width - 2)
                            return false;
                        if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                            return false;
                        y++;
                    }
                    y = y1;
                    x++;
                }
            }
            else
            {
                s = (s * 3) / 2;
                for (int i = 1; i <= s; i++)
                {
                    for (int j = 0; j < (s - i); j++)
                        y++;
                    for (int j = 1; j <= i; j++)
                    {
                        if (x > length - 2 || y > width - 2)
                            return false;
                        if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                            return false;
                        y++;
                    }
                    for (int k = 1; k < i; k++)
                    {
                        if (x > length - 2 || y > width - 2)
                            return false;
                        if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                            return false;
                        y++;
                    }
                    y = y1;
                    x++;
                }

                for (int i = s - 1; i >= 1; i--)
                {
                    for (int j = 0; j < (s - i); j++)
                        y++;
                    for (int j = 1; j <= i; j++)
                    {
                        if (x > length - 2 || y > width - 2)
                            return false;
                        if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                            return false;
                        y++;
                    }
                    for (int k = 1; k < i; k++)
                    {
                        if (x > length - 2 || y > width - 2)
                            return false;
                        if (gameBoard[x, y].symbol.CompareTo("#") != 0)
                            return false;
                        y++;
                    }
                    y = y1;
                    x++;
                }
            }
            return true;
        }
        //makes odd shaped room
        private void makeOddRoom(int s, int o, int x, int y)
        {
            int y1 = y;
            if (o < 40)
            {
                for (int a = 0; a <= s; a++)
                {
                    for (int b = 0; b <= a; b++)
                    {
                        setFloor(x, y);
                        y++;
                    }
                    y = y1;
                    x++;
                }
            }
            else
            {
                s = (s * 3) / 2;
                for (int i = 1; i <= s; i++)
                {
                    for (int j = 0; j < (s - i); j++)
                        y++;
                    for (int j = 1; j <= i; j++)
                    {
                        setFloor(x, y);
                        y++;
                    }
                    for (int k = 1; k < i; k++)
                    {
                        setFloor(x, y);
                        y++;
                    }
                    y = y1;
                    x++;
                }

                for (int i = s - 1; i >= 1; i--)
                {
                    for (int j = 0; j < (s - i); j++)
                        y++;
                    for (int j = 1; j <= i; j++)
                    {
                        setFloor(x, y);
                        y++;
                    }
                    for (int k = 1; k < i; k++)
                    {
                        setFloor(x, y);
                        y++;
                    }
                    y = y1;
                    x++;
                }
            }
        }
        //checks to see if can place stairs
        public bool checkStairs(int x, int y)
        {
            if (gameBoard[x, y].stairsHere)
                return true;
            return false;
        }
        //moves player down
        public void moveDOWN(int x, int y)
        {
            try {
                if (Movement.canMove(gameBoard[x, y + 1]))
                {
                    gameBoard[x, y].playerHere = false;
                    gameBoard[x, y + 1].playerHere = true;
                }
            }
            catch (IndexOutOfRangeException i)
            {
            }
        }
        //moves player up
        public void moveUP(int x, int y)
        {
            try
            {
                if (Movement.canMove(gameBoard[x, y - 1]))
                {
                    gameBoard[x, y].playerHere = false;
                    gameBoard[x, y - 1].playerHere = true;
                }
            }
            catch (IndexOutOfRangeException i)
            {
            }
        }
        //moves player right
        public void moveRIGHT(int x, int y)
        {
            try
            {
                if (Movement.canMove(gameBoard[x + 1, y]))
                {
                    gameBoard[x, y].playerHere = false;
                    gameBoard[x + 1, y].playerHere = true;
                }
            }
            catch (IndexOutOfRangeException i)
            {
            }
        }
        //moves player left
        public void moveLEFT(int x, int y)
        {
            try {
                if (Movement.canMove(gameBoard[x - 1, y]))
                {
                    gameBoard[x, y].playerHere = false;
                    gameBoard[x - 1, y].playerHere = true;
                }
            }
            catch (IndexOutOfRangeException i)
            {
            }
        }
    }
}
