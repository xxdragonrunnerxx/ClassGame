/***********************************************************
  * Bradley Massey
  * 12/3/2015
  * C#
  * Movement
  * 
  * 
  * canMove()
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class Movement
    {
        //checks is you can move to next tile
        public static bool canMove(tile t)
        {
            if (t.isWall())
                return true;
            else
                return false;
        }
    }
}
