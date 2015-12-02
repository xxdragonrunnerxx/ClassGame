using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class generalStore : business, IShop

    { //variables to hold (respectively) the list of items in stock, people in the shop other than the owner, list of items available for purchase    List<Item> inventory;
        List<Person> patrons;
        List<consumable> itemList;

        public generalStore(List<consumable> il, List<Person> p, int h, int w, int rooms, Person o) : base(h, w, rooms, o)
        {
            itemList = il;
            patrons = p;

        }


        public void buyConsumable(consumable i)
        {
            Console.WriteLine("Oooo " + i.name + ". A rather tasty choice. \nEnjoy!");
            //add item to inventory
        }


        public void showInventory()
        {
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    Console.WriteLine(i + "." + itemList[i].name + "\t\t Price:" + itemList[i].price + "\n");

                }
                Console.WriteLine("\n\nEnter the corresponding number to purchase any item.");
            }
        }

        public override void Greetings()
        {
            Console.WriteLine("Hey there traveller..\n\nWelcome to my shop. Here you can purchase consumable items. \n\nYou can either (V)iew my current stock or (T)alk to some folks around the shop.");
        }

        public void Mingle()
        {
            int mingleInput = 0;

            Console.WriteLine("Who would you like to speak with?");

            for (int i = 0; i <= patrons.Count; i++)
            {
                Console.WriteLine(i + "." + patrons[i].Name);
            }

            Console.WriteLine("Enter the corresponding number of who you wish to talk to.");
            mingleInput = Console.Read();

            Console.WriteLine(patrons[mingleInput].Story);
        }

        public void buyItem(equipItem i)
        {
            throw new NotImplementedException();
        }

    }
}