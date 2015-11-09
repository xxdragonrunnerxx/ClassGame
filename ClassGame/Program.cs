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
            bool again = true;
            gameSave save;
            playerClass character;
            int floor=0;
            board[] gameMaps = new board[15];
            do
            {
                Console.Write("Do you want to load a game?Y/N");
                string continued = Console.ReadLine();
                char c = Char.ToUpper(continued.FirstOrDefault());
                switch (c)
                {
                    case 'Y':
                        save = loadGame();

                        character = save.player;
                        gameMaps = save.gameBoard;
                        floor = save.floor;
                        again = false;
                        break;
                    case 'N':
                        character = newPlayer();
                        gameMaps = newMaps();
                        again = false;
                        break;
                    default:
                        character = newPlayer();
                        gameMaps = newMaps();
                        again = false;
                        break;
                }
            } while (again);
            MainGame.Play(character, gameMaps, floor);
            Save(character, gameMaps, floor);
        }
        public static void Save(playerClass p, board[] b, int f)
        {
            gameSave save = new gameSave(p, b, f);
            saveGame(save);
        }
        public static board[] newMaps()
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
            return map;
        }
        public static void saveGame(gameSave save)
        {
            bool repeat = false;
            string fileName = "test.dat";
            do
            {
                printSaves();

                Console.Write("Which slot do you want to save in?(1 2 3 4)");
                string saveSlot = Console.ReadLine();
                saveSlot = validSave(saveSlot);
                if (saveSlot.CompareTo("no save") == 0)
                { return; }
                char c = Char.ToUpper(saveSlot.FirstOrDefault());
                switch (c)
                {
                    case '1':
                        fileName = "save1.dat";
                        repeat = false;
                        break;
                    case '2':
                        fileName = "save2.dat";
                        repeat = false;
                        break;
                    case '3':
                        fileName = "save3.dat";
                        repeat = false;
                        break;
                    case '4':
                        fileName = "save4.dat";
                        repeat = false;
                        break;
                    default:
                        repeat = true;
                        break;
                }
            } while (repeat);
            System.IO.Stream fs = File.OpenWrite(fileName);

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fs, save);
            Console.Write("Game saved!");
            fs.Flush();
            fs.Close();
            fs.Dispose();

        }
        private static string validSave(string saveSlot)
        {
            int saveNumber;
            bool again = true;
            do
            {
                while (int.TryParse(saveSlot, out saveNumber) == false)
                {
                    Console.WriteLine("You did not enter a valid save slot.");
                    Console.Write("Please enter a valid save slot:");
                    saveSlot = Console.ReadLine();
                }
                if (saveNumber >= 1 && saveNumber <= 4)
                    again = false;
                else
                {
                    Console.WriteLine("You did not enter a valid save slot.");
                    Console.Write("Please enter a valid save slot:");
                    saveSlot = Console.ReadLine();
                }
            } while (again);
            return saveSlot;
        }
        public static void printSaves()
        {
            gameSave save;
            string fileName = "test.dat";
            for (int x = 1; x <= 4; x++)
            {

                Console.WriteLine("");
                Console.WriteLine("Save " + x + ":");
                fileName = "save" + x + ".dat";
                try
                {
                    System.IO.Stream fs = File.Open(fileName, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();

                    object obj = formatter.Deserialize(fs);
                    save = (gameSave)obj;
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                    Console.WriteLine("Name: " + save.player.getName());
                    Console.WriteLine("Floor: " + save.floor);
                }
                catch (FileNotFoundException save1)//catches if can't find file
                {
                    Console.WriteLine("No Save File.");
                }
                catch (ArgumentException save1)
                {
                    Console.WriteLine("Please enter a file name.");
                }
            }
        }
        public static gameSave loadGame()
        {
            gameSave save;
            string fileName = "test.dat";
            do
            {
                printSaves();
                Console.Write("Which slot do you want to load from?(1 2 3 4)");
                string saveSlot = Console.ReadLine();
                saveSlot = validSave(saveSlot);
                char c = Char.ToUpper(saveSlot.FirstOrDefault());
                switch (c)
                {
                    case '1':
                        fileName = "save1.dat";
                        break;
                    case '2':
                        fileName = "save2.dat";
                        break;
                    case '3':
                        fileName = "save3.dat";
                        break;
                    case '4':
                        fileName = "save4.dat";
                        break;
                    default:
                        break;
                }
                try
                {
                    System.IO.Stream fs = File.Open(fileName, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();

                    object obj = formatter.Deserialize(fs);
                    save = (gameSave)obj;
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                    return save;
                }
                catch (FileNotFoundException save1)//catches if can't find file
                {
                    Console.WriteLine("Could not find that save file.");
                }
                catch (ArgumentException save1)
                {
                    Console.WriteLine("Please enter a file name.");
                }

            } while (true);


        }
        public static playerClass newPlayer()
        {
            playerClass character;
            bool again = true;
            do
            {
                character = playerClass.newPlayer();
                Console.WriteLine("Name: " + character.getName());
                Console.WriteLine(character.getHistory());
                Console.WriteLine(character.getGender());
                if (!playerClass.newCharacter())
                    break;
                Console.Write("Continue?(Y)es or (N)o?");
                string continued = Console.ReadLine();
                char c = Char.ToUpper(continued.FirstOrDefault());
                switch (c)
                {
                    case 'Y':
                        again = false;
                        break;
                    case 'N':
                        break;
                    default:
                        again = false;
                        break;
                }
            } while (again && playerClass.newCharacter());
            return character;
        }
    }
}
