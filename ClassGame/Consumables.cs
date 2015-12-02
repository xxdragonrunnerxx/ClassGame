using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
     
    class consumable
    {
        public string name;
        public int atkUp;
        public int defUp;
        public int healthUp;
        public int rarity;
        public double price;

        public consumable(string n, int aUp = 0, int dUp = 0, int hUp = 0, int r = 0, double p = 0)
        {
            name = n;
            atkUp = aUp;
            defUp = dUp;
            healthUp = hUp;
            rarity = r;
            price = p;
        }
        public static consumable genConsumable()
        {
            List<consumable> C = new List<consumable>
        {
            new consumable("Bath Salts",3,10,8,75),
            new consumable("Meat SandWich",2,2,4,25),
            new consumable("Mad Dog 20/20",1,1,1,15),
            new consumable("Small Red Bull",3,3,3,35),
            new consumable("Large Red Bull",4,4,4,40),
            new consumable("McDonalds Leftovers",4,4,1,45),
            new consumable("Magical Brownies",5,5,5,50),
            new consumable("Cake",1,5,4,55),
            new consumable("Birds Nest Complete with Eggs",5,1,3,60),
            new consumable("Zebra Stripe Gum",3,7,2,65),
            new consumable("Dozen Donuts",5,4,6,70),
            new consumable("Half of a Pizza",3,10,8,90),
            new consumable("An unopened box of fortune cookies",10,10,10,100),
        };

            int stat1 = StaticRandom.Instance.Next(1, 110);

            consumable con = (from consumable in C
                                where consumable.rarity <= stat1
                                orderby consumable.rarity descending
                                select consumable).FirstOrDefault();

            return con;



        }
    }
}

