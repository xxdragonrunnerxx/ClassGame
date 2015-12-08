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
            Console.Clear();
            Console.WriteLine("\n\nOooo " + i.name + ". \n\nA rather tasty choice. \n\nEnjoy!");
            //Console.ReadKey();
            
            //add item to inventory
            //subtract from players money
            
        }
        public void tab(int i)
        {
            int[] tabAmount = new int[itemList.Count];
            for (int x = 0; x < itemList.Count; x++)
            {
                tabAmount[x] = (itemList[x].name.Length / 8) + 1;
            }
            int largest = tabAmount[itemList.Count-1];
            for (int x = 0; x < itemList.Count; x++)
            {

                if (tabAmount[x] > largest)
                {
                    largest = tabAmount[x];

                }
            }
            for (int x = 0; x < itemList.Count; x++)
            {
                if (itemList[x].name.Length % 8 > 5)
                    tabAmount[x] = largest - tabAmount[x] - 1;
                else
                    tabAmount[x] = largest - tabAmount[x];
            }
            for (
                int x = 0; x <= tabAmount[i]; x++)
            {
                Console.Write("\t");
            }
        }

        public void showInventory()
        {
            {
                string purchaseInput = "";
                int number;
                bool flag = true;

                Console.Clear();
                //Iterates through the shops list of items and display them
                do
                {
                    if (itemList.Count == 0)
                    {
                        Console.WriteLine("I seem to be out of inventory at this moment. \n\nPress Enter to proceed...");
                        Console.ReadKey();
                        return;

                    }
                    else
                    {
                        for (int i = 0; i < itemList.Count; i++)
                        {
                            Console.Write(i + 1 + "." + itemList[i].name);
                            tab(i);
                            Console.WriteLine("Price:" + itemList[i].price + "\n");

                        }
                        Console.WriteLine("\n\nEnter the corresponding number to purchase any item or Enter to go back.");

                        purchaseInput = Console.ReadLine();

                        if (purchaseInput == "")
                            return;
                        //Attempts to turn string input into an int
                        bool result = Int32.TryParse(purchaseInput, out number);
                        number--;

                        if (result)
                        {
                            try
                            {
                                buyConsumable(itemList[number]);
                                itemList.RemoveAt(number);
                            }
                            catch (ArgumentOutOfRangeException e)
                            {
                                Console.WriteLine("I'm sorry but I'm sold out of those...\nTry purchasing something that's in stock");
                            }
                        }

                        //Check to see if the user wants to buy another item
                        Console.WriteLine("\n\nWould you like to purchase something else? (Y/N)");

                        ConsoleKeyInfo cki;
                        cki = Console.ReadKey();

                        if (cki.Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            flag = true;
                        }

                        else if (cki.Key == ConsoleKey.N)
                        {
                            Console.Clear();
                            flag = false;
                        }
                    }
                } while (flag);
            }
        }

        public override void Greetings()
        {
            Console.WriteLine("Hey there traveller..\n\nWelcome to my shop. Here you can purchase consumable items. \n\nYou can either (V)iew my current stock, (T)alk to some folks around the shop, or (L)eave the shop.");
        }

        public void Mingle()
        {
            //Variables will get the input and store into "number" if tryParse is successful
            string mingleInput = "";
            int number;
            bool flag = true;

            do
            {
                Console.WriteLine("Who would you like to speak with?\n\n");

                //Lists the available patrons
                for (int i = 0; i < patrons.Count; i++)
                {
                    Console.WriteLine(i + 1 + "." + patrons[i].Name);
                    Console.WriteLine("\n");
                }


                Console.WriteLine("Enter the corresponding number of who you wish to talk to.");
                mingleInput = Console.ReadLine();

                //Attempts to turn string input into an int
                bool result = Int32.TryParse(mingleInput, out number);
                if (result)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(patrons[number - 1].Name);
                        Console.WriteLine("\n\n");
                        Console.WriteLine(patrons[number - 1].Story);
                        Console.ReadKey();
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("I'm sorry but that person isn't here...\n\n\nPress Enter to return");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                //Check to see if the user wants to view another story
                Console.Clear();
                Console.WriteLine("Would you like to try talking with someone else? (Y/N)");

                ConsoleKeyInfo cki;
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    flag = true;
                }

                else if (cki.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    flag = false;
                    return;
                }

            } while (flag);
        }

        public void buyItem(equipItem i)
        {
            throw new NotImplementedException();
        }

        public void enterShop()
        {
            bool again = true;
            do
            {
                Console.Clear();
                Greetings();

                ConsoleKeyInfo cki;
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.T)
                {
                    Console.Clear();
                    Mingle();
                }

                else if (cki.Key == ConsoleKey.V)
                {
                    Console.Clear();
                    showInventory();
                }

                else if (cki.Key == ConsoleKey.L)
                {
                    //This Doesn't work properly
                    Console.Clear();
                    again = false;
                }
            } while (again);

        }
    }
}