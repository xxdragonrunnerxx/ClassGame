﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class money
    {
        int gold = 0;

        public void startingGold()
        {
            gold = dieroller.totalRoll(10, 6);
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
