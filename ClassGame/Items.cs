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
                new material("Wood",1,1,1,1),
                new material("Steel",3,4,2,50),
                new material("Iron",4,3,2,40),
                new material("Plastic",0,0,2,10),
                new material("Polymer",3,5,5,60),
                new material("Chainmail",2,4,1,70),
                new material("Adamantine",7,7,6,90),
                new material("Gold",5,5,5,65),
                new material("Silver",4,4,4,55),
                new material("Bone",4,8,6,80),
                new material("Stone",1,2,2,20),
                new material("Bronze",4,3,3,27),
                new material("Copper",3,4,3,33),
                new material("Obsidian",7,7,7,100),
            };

            List<material> Armor = new List<material>
            {
                new material("Tunic",1,1,1,1),
                new material("Robe",3,4,2,30),
                new material("Riot Suit",4,3,2,45),
                new material("Helmet",0,0,2,35),
                new material("Ballistic Vest",3,5,5,40),
                new material("BattleDress",2,4,1,15),
                new material("BombSuit",7,7,6,20),
                new material("Kilt",3,5,5,25),
                new material("TrenchCoat",4,4,4,50),
                new material("HazMat Suit",8,5,5,100),
                new material("Cuirass",1,2,2,55),
                new material("Linothorax",2,2,2,60),
                new material("ExoSkeleton",7,7,6,90),
                new material("Protective Bubble",7,7,7,95),
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

            equipItem armor = new equipItem(fullName, newAtk, newDef, newHealth);

            return armor;
        }

    

        public static equipItem genWeapon()
    {
        List<material> M = new List<material>
            {
                new material("Wood",1,1,1,1),
                new material("Steel",3,4,2,50),
                new material("Iron",4,3,2,40),
                new material("Plastic",0,0,2,10),
                new material("Polymer",3,5,5,60),
                new material("Chainmail",2,4,1,70),
                new material("Adamantine",7,7,6,90),
                new material("Gold",5,5,5,65),
                new material("Silver",4,4,4,55),
                new material("Bone",4,8,6,80),
                new material("Stone",1,2,2,20),
                new material("Bronze",4,3,3,27),
                new material("Copper",3,4,3,33),
                new material("Obsidian",7,7,7,100),
            };

        List<material> WeaponItem = new List<material>
            {
                new material("SlingShot",1,1,1,1),
                new material("Dagger",3,4,2,10),
                new material("Mace",4,3,2,27),
                new material("Bow",3,5,2,20),
                new material("Whip",3,5,5,35),
                new material("DartGun",2,4,1,44),
                new material("Musket",7,7,6,51),
                new material("ChainSaw",5,5,5,59),
                new material("Sword",4,4,4,66),
                new material("Uzi",8,5,5,100),
                new material("Staff",1,2,2,75),
                new material("Boomerang",2,2,2,85),
                new material("Trident",7,7,6,95),
                new material("Rocket Launcher",7,7,7,105),
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
        double price = StaticRandom.Instance.Next(10,100);


        equipItem weapon = new equipItem(fullName, newAtk, newDef, newHealth,price);

        return weapon;
    }


        public static equipItem genShield() 
        {
            List<material> M = new List<material>
            {
                new material("Wood",1,1,1,1),
                new material("Steel",3,4,2,50),
                new material("Iron",4,3,2,40),
                new material("Plastic",0,0,2,10),
                new material("Polymer",3,5,5,60),
                new material("Chainmail",2,4,1,70),
                new material("Adamantine",7,7,6,90),
                new material("Gold",5,5,5,65),
                new material("Silver",4,4,4,55),
                new material("Bone",4,8,6,80),
                new material("Stone",1,2,2,20),
                new material("Bronze",4,3,3,27),
                new material("Copper",3,4,3,33),
                new material("Obsidian",7,7,7,100),
            };

            List<material> Shield = new List<material>
            {
                new material("Broken",1,1,1,1),
                new material("Scotum",3,4,2,25),
                new material("Buckler",4,3,2,60),
                new material("Kite",2,2,2,30),
                new material("Heater",3,5,5,70),
                new material("Cracked",2,4,1,10),
                new material("Tower",7,7,6,20),
                new material("Parma",3,5,5,55),
                new material("Klar",4,4,4,75),
                new material("Boss",3,5,5,80),
                new material("Light",1,2,2,50),
                new material("Heavy",2,2,2,45),
                new material("QuickDraw",7,7,6,90),
                new material("Magical",7,7,7,100),
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

            equipItem shield = new equipItem(fullName, newAtk, newDef, newHealth);

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

        public material(string n, int aUp = 0, int dUp = 0, int hUp = 0, int r = 0)
        {
            name = n;
            rarity = r;
            atkUp = aUp;
            defUp = dUp;
            healthUp = hUp;
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