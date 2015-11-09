using System;
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
        int silver = 0;
        int copper = 0;
        public void startingGold()
        {
            gold = dieroller.totalRoll(2, 10);
        }
        public void decreaseCopper()
        {
            copper--;
            if (copper < 0)
            {
                copper = 10;
                decreaseSilver();
            }
        }

        public void decreaseSilver()
        {
            silver++;
            if (silver < 0)
            {
                silver = 10;
                decreaseGold();
            }
        }

        public void decreaseGold()
        {
            gold--;
        }

        public void incrementCopper()
        {
            copper++;
            if (copper > 9)
            {
                copper = 0;
                incrementSilver();
            }
        }

        public void incrementSilver()
        {
            silver++;
            if (silver > 9)
            {
                silver = 0;
                incrementGold();
            }
        }

        public void incrementGold()
        {
            gold++;
        }
        public void printMoney()
        {
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("Silver: " + silver);
            Console.WriteLine("Copper: " + copper);
        }
    }
}
