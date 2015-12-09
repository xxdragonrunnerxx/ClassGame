using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class Item
    {

        public static equipItem genArmor()
        {

            List<material> M = new List<material>
            {
                new material("Wood",1,1,1,1,8),
                new material("Steel",3,4,2,50,25),
                new material("Iron",4,3,2,40,20),
                new material("Plastic",0,0,2,10,10),
                new material("Polymer",3,5,5,60,30),
                new material("Chainmail",2,4,1,70,35),
                new material("Adamantine",7,7,6,90,45),
                new material("Gold",5,5,5,65,33),
                new material("Silver",4,4,4,55,30),
                new material("Bone",4,8,6,80,45),
                new material("Stone",1,2,2,20,15),
                new material("Bronze",4,3,3,27,18),
                new material("Copper",3,4,3,33,20),
                new material("Obsidian",7,7,7,100,50),
            };

            List<material> Armor = new List<material>
            {
                new material("Tunic",1,1,1,1,5),
                new material("Robe",3,4,2,30,24),
                new material("Riot Suit",4,3,2,45,40),
                new material("Helmet",0,0,2,35,30),
                new material("Ballistic Vest",3,5,5,40,35),
                new material("BattleDress",2,4,1,15,10),
                new material("BombSuit",7,7,6,20,13),
                new material("Kilt",3,5,5,25,18),
                new material("TrenchCoat",4,4,4,50,45),
                new material("HazMat Suit",8,5,5,100,60),
                new material("Cuirass",1,2,2,55,47),
                new material("Linothorax",2,2,2,60,50),
                new material("ExoSkeleton",7,7,6,90,54),
                new material("Protective Bubble",7,7,7,95,58),
            };

            int stat1 = StaticRandom.Instance.Next(1, 110);
            int stat2 = StaticRandom.Instance.Next(1, 110);



            material mat = (from material in M
                            where material.rarity <= stat1
                            orderby material.rarity descending
                            select material).FirstOrDefault();

            material item = (from material in Armor
                             where material.rarity <= stat2
                             orderby material.rarity descending
                             select material).FirstOrDefault();

            int newAtk = mat.atkUp + item.atkUp;
            int newDef = mat.defUp + item.defUp;
            int newHealth = mat.healthUp + item.healthUp;
            string fullName = mat.name + " " + item.name;
            double price = mat.price + item.price;


            equipItem armor = new equipItem(fullName, newAtk, newDef, newHealth,price);

            return armor;
        }

    

        public static equipItem genWeapon()
    {
        List<material> M = new List<material>
            {
                new material("Wood",1,1,1,1,8),
                new material("Steel",3,4,2,50,25),
                new material("Iron",4,3,2,40,20),
                new material("Plastic",0,0,2,10,10),
                new material("Polymer",3,5,5,60,30),
                new material("Chainmail",2,4,1,70,35),
                new material("Adamantine",7,7,6,90,45),
                new material("Gold",5,5,5,65,33),
                new material("Silver",4,4,4,55,30),
                new material("Bone",4,8,6,80,45),
                new material("Stone",1,2,2,20,15),
                new material("Bronze",4,3,3,27,18),
                new material("Copper",3,4,3,33,20),
                new material("Obsidian",7,7,7,100,50),
            };

        List<material> WeaponItem = new List<material>
            {
                new material("SlingShot",1,1,1,1,10),
                new material("Dagger",3,4,2,10,17),
                new material("Mace",4,3,2,27,30),
                new material("Bow",3,5,2,20,24),
                new material("Whip",3,5,5,35,36),
                new material("DartGun",2,4,1,44,41),
                new material("Musket",7,7,6,51,45),
                new material("ChainSaw",5,5,5,59,55),
                new material("Sword",4,4,4,66,60),
                new material("Uzi",8,5,5,100,90),
                new material("Staff",1,2,2,75,65),
                new material("Boomerang",2,2,2,85,70),
                new material("Trident",7,7,6,95,80),
                new material("Rocket Launcher",7,7,7,105,100),
            };

        int stat1 = StaticRandom.Instance.Next(1, 110);
        int stat2 = StaticRandom.Instance.Next(1, 110);



        material mat = (from material in M
                        where material.rarity <= stat1
                        orderby material.rarity descending
                        select material).FirstOrDefault();

        material item = (from material in WeaponItem
                         where material.rarity <= stat2
                         orderby material.rarity descending
                         select material).FirstOrDefault();

        int newAtk = mat.atkUp + item.atkUp;
        int newDef = mat.defUp + item.defUp;
        int newHealth = mat.healthUp + item.healthUp;
        string fullName = mat.name + " " + item.name;
        double price = mat.price + item.price;


        equipItem weapon = new equipItem(fullName, newAtk, newDef, newHealth,price);

        return weapon;
    }


        public static equipItem genShield() 
        {
            List<material> M = new List<material>
            {
                new material("Wood",1,1,1,1,8),
                new material("Steel",3,4,2,50,25),
                new material("Iron",4,3,2,40,20),
                new material("Plastic",0,0,2,10,10),
                new material("Polymer",3,5,5,60,30),
                new material("Chainmail",2,4,1,70,35),
                new material("Adamantine",7,7,6,90,45),
                new material("Gold",5,5,5,65,33),
                new material("Silver",4,4,4,55,30),
                new material("Bone",4,8,6,80,45),
                new material("Stone",1,2,2,20,15),
                new material("Bronze",4,3,3,27,18),
                new material("Copper",3,4,3,33,20),
                new material("Obsidian",7,7,7,100,50),
            };

            List<material> Shield = new List<material>
            {
                new material("Broken",1,1,1,1,7),
                new material("Scotum",3,4,2,25,18),
                new material("Buckler",4,3,2,60),
                new material("Kite",2,2,2,30,20),
                new material("Heater",3,5,5,70,45),
                new material("Cracked",2,4,1,10,10),
                new material("Tower",7,7,6,20,15),
                new material("Parma",3,5,5,55,40),
                new material("Klar",4,4,4,75,50),
                new material("Boss",3,5,5,80,55),
                new material("Light",1,2,2,50,35),
                new material("Heavy",2,2,2,45,30),
                new material("QuickDraw",7,7,6,90,60),
                new material("Magical",7,7,7,100,65),
            };



            int stat1 = StaticRandom.Instance.Next(1, 110);
            int stat2 = StaticRandom.Instance.Next(1, 110);



            material mat = (from material in M
                            where material.rarity <= stat1
                            orderby material.rarity descending
                            select material).FirstOrDefault();

            material item = (from material in Shield
                             where material.rarity <= stat2
                             orderby material.rarity descending
                             select material).FirstOrDefault();

            int newAtk = mat.atkUp + item.atkUp;
            int newDef = mat.defUp + item.defUp;
            int newHealth = mat.healthUp + item.healthUp;
            string fullName = mat.name + " " + item.name + " shield";
            double price = mat.price + item.price;

            equipItem shield = new equipItem(fullName, newAtk, newDef, newHealth,price);

            return shield;
        }

    }

    class material
    {
        public string name;
        public int rarity;
        public int atkUp;
        public int defUp;
        public int healthUp;
        public double price;

        public material(string n, int aUp = 0, int dUp = 0, int hUp = 0, int r = 0, double p = 0)
        {
            name = n;
            rarity = r;
            atkUp = aUp;
            defUp = dUp;
            healthUp = hUp;
            price = p;
        }
    }

    class equipItem
    {
        public string name;
        public int atkUp;
        public int defUp;
        public int healthUp;
        public double price;

        public equipItem(string n, int aUp = 0, int dUp = 0, int hUp = 0, double p = 0)
        {
            name = n;
            atkUp = aUp;
            defUp = dUp;
            healthUp = hUp;
            price = p;
        }
    }
}