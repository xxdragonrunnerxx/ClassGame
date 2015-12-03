/***********************************************************
  * Bradley Massey
  * 9/6/2015
  * C#
  * tile
  * 
  * 
  * tile(string s, ConsoleColor f, ConsoleColor b, bool w)
  * isWall()
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class tile
    {
        //variables
        public string symbol { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public bool playerHere { get; set; }
        public bool stairsHere { get; set; }
        public bool wall { get; set; }
        public bool door { get; set; }
        //creates tile
        public tile(string s, ConsoleColor f, ConsoleColor b, bool w)
        {
            symbol = s;
            ForegroundColor = f;
            BackgroundColor = b;
            playerHere = false;
            stairsHere = false;
            wall = w;
        }
        //checks if wall
        public bool isWall()
        {
            if (wall)
                return false;
            else
                return true;
        }

    }
}
