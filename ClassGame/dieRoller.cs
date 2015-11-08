/***********************************************************
  * Bradley Massey
  * 9/6/2015
  * C#
  * dieroller
  * 
  * 
  * die roller
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassGame
{
    //die roller class
    static class dieroller
    {
        //roll d(s)
        private static int roll(int s)
        {
            int die = StaticRandom.Instance.Next(1, s + 1);
            return die;
        }
        //roll (t)d(s) or 3d6
        public static int totalRoll(int t = 3, int s = 6)
        {
            int total = 0;
            for (int x = 0; x < t; x++)
            {
                total = total + roll(s);
            }
            return total;
        }
        //roll (t)d(s) and check if it beats target
        public static int targetRoll(int t, int s, int target)
        {
            int total = 0;
            for (int x = 0; x < t; x++)
            {
                int die = roll(s);
                if (die >= target)
                    total++;
            }
            return total;
        }
    }
}
