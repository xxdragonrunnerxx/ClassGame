using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class Movement
    {
        public static bool canMove(tile t)
        {
            if (t.isWall())
                return true;
            else
                return false;
        }
    }
}
