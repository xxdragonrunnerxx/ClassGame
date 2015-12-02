using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class money
    {
        int gold = 0;

        public void startingGold()
        {
            gold = dieroller.totalRoll();
        }

        public void decreaseGold()
        {
            gold--;
        }

        public void incrementGold()
        {
            gold++;
        }

        public void printGold()
        {
            Console.WriteLine("Gold: " + gold);
        }
    }
}
