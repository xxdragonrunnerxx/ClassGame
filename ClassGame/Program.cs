/***********************************************************
  * Bradley Massey
  * 12/3/2015
  * C#
  * Program
  * 
  * 
  * Save(playerClass p, board[] b, int f)
  * newMaps()
  * saveGame(gameSave save)
  * validSave(string saveSlot)
  * callSave(int x)
  * printSaves()
  * loadGame()
  * newPlayer()
  ***********************************************************/
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
        //set window size
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
            //set window size
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            //variables
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
        }
        //sets up gamesave
        public static void Save(playerClass p, board[] b, int f)
        {
            gameSave save = new gameSave(p, b, f);
            saveGame(save);
        }
        //creates mapes for game
        public static board[] newMaps()
        {
            String[] story = Story.newStory();
            board[] map = new board[15];
            map[0] = new board(60);
            map[1] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3), 20);
            map[2] = new board(60);
            map[3] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[4] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[5] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[6] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[7] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[8] = new board(dieroller.totalRoll(35, 2), dieroller.totalRoll(50, 3), 15);
            map[9] = new board(60);
            map[10] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[11] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[12] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[13] = new board(dieroller.totalRoll(50, 3), dieroller.totalRoll(35, 2));
            map[14] = new board(70, 180);
            for (int i = 0; i < 15; i++ )
            {
                map[i].story = story[i];
            }
                return map;
        }
        //saves game
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
            Console.WriteLine("Game saved!");
            fs.Flush();
            fs.Close();
            fs.Dispose();

        }
        //checks if it is a valid save
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
        //calls save file
        public static gameSave callSave(int x)
        {
            gameSave save;
            string fileName = "test.dat";
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
                return save;
            }
            catch (FileNotFoundException save1)//catches if can't find file
            {
            }
            catch (ArgumentException save1)
            {
            }
            return new gameSave(new playerClass(), new board[15], 0);

        }
        //prints all save slots
        public static void printSaves()
        {
            Console.Clear();
            gameSave save1 = callSave(1);
            gameSave save2 = callSave(2);
            gameSave save3 = callSave(3);
            gameSave save4 = callSave(4);

            Console.WriteLine("");
            Console.WriteLine("Save 1:");
            Console.WriteLine("Name: " + save1.player.getName());
            Console.WriteLine("Floor: " + save1.floor);
            Console.WriteLine("");
            Console.WriteLine("Save 2:");
            Console.WriteLine("Name: " + save2.player.getName());
            Console.WriteLine("Floor: " + save2.floor);
            Console.WriteLine("");
            Console.WriteLine("Save 3:");
            Console.WriteLine("Name: " + save3.player.getName());
            Console.WriteLine("Floor: " + save3.floor);
            Console.WriteLine("");
            Console.WriteLine("Save 4:");
            Console.WriteLine("Name: " + save4.player.getName());
            Console.WriteLine("Floor: " + save4.floor);
        }
        //loads save file
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
        //creates new player
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
