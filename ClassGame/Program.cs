using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace ClassGame
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            MainGame();

        }
        public static void MainGame()
        {
            board[] map = new board[15];
            map[0] = new board(60);
            map[1] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3), 20);
            map[2] = new board(60);
            map[3] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[4] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[5] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[6] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[7] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[8] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3), 15);
            map[9] = new board(60);
            map[10] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[11] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[12] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[13] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3));
            map[14] = new board(70, 180);
            
        }
    }
}
