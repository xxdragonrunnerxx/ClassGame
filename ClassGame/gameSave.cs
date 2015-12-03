using System;
using System.Collections.Generic;
using System.Linq;
/***********************************************************
  * Bradley Massey
  * 9/6/2015
  * C#
  * gameSave
  * 
  * 
  * gameSave(playerClass p, board[] b, int f)
  ***********************************************************/
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class gameSave
    {
        //variables
        public playerClass player { get; set; }
        public board[] gameBoard { get; set; }
        public int floor { get; set; }
        //creates gameSave
        public gameSave(playerClass p, board[] b, int f)
        {
            player = p;
            gameBoard = b;
            floor = f;
        }
    }

}
