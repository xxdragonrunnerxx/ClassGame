﻿/***********************************************************
  * Bradley Massey
  * 9/6/2015
  * C#
  * Board
  * 
  * 
  * 
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class board
    {
        private tile[,] gameBoard;
        public int length= dieroller.totalRoll(10, 7);
        public int width=dieroller.totalRoll(10, 15);
        public static int rooms = 15;
        public int counts = 0;
        public int[,] Center = new int[rooms, 2];
        //creates wilderness
        public board(int x)
        {
            gameBoard = new tile[length, width];
            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    gameBoard[a, b] = new tile(".", ConsoleColor.Blue, ConsoleColor.DarkGreen, true);
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
                    gameBoard[a, b].wall = false;
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
                newBuilding();
            }
            inverseFloor(length, width);
            setPlayer();
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
        //prints board
        public void printBoard()
        {

            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    if (gameBoard[a, b].playerHere || gameBoard[a, b].stairsHere)
                    {
                        if (gameBoard[a, b].playerHere)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write("@");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(">");
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
        private void newBuilding()
        {
            int x = dieroller.totalRoll(1, length);
            int y = dieroller.totalRoll(1, width);
            int h = dieroller.totalRoll(3, 5);
            int w = dieroller.totalRoll(3, 5);
            if (checkBuilding(h, w, x, y))
            {
                counts++;
                makeRoom(h, w, x, y);
            }
            else
                newBuilding();
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
        private void setFloor(int x, int y)
        {
            gameBoard[x, y].symbol = "`";
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.Green;
        }
        private void setWildernessFloor(int x, int y)
        {
            gameBoard[x, y].symbol = ".";
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkGreen;
        }
        private void setSidewalk(int x, int y)
        {
            gameBoard[x, y].symbol = ".";
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkGreen;
        }
        private void setBuilding(int x, int y)
        {
            gameBoard[x, y].symbol = "‡";
            gameBoard[x, y].ForegroundColor = ConsoleColor.Blue;
            gameBoard[x, y].BackgroundColor = ConsoleColor.DarkGreen;
        }
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
                        gameBoard[a, b].ForegroundColor = ConsoleColor.Blue;
                        gameBoard[a, b].BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        gameBoard[a, b].wall = false;
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
    }
}