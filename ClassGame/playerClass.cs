using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class playerClass
    {
        int level;
        string name;
        string history;
        int health;

        money playerMoney;
        int[] satus = new int[3];
        int[] modify = new int[3];

        string[] statName = { "Strength", "Defense", "Health" };

        static bool newCharacterSelect = true;

        public playerClass()
        {
            level = 1;
            name = genName();
            history = genHis();
            rollStats();
            playerMoney = new money();
            playerMoney.startingGold();
            modSet();
        }

        public void printMoney()
        {
            playerMoney.printGold();
        }

        public playerClass(int l, string s)
        {
            level = l;
            s = s.ToUpper();
            if (s == "MALE")
            {
                name = genMaleName();
            }
            else
            {
                name = genFemaleName();
            }
            history = genHis();
            rollStats();
            modSet();
        }

        public static bool newCharachter()
        {
            return newCharacterSelect;
        }

        public int modifier(int stat)
        {
            return (stat - 10) / 2;
        }

        private void modSet()
        {
            for (int x = 0; x < 3; x++) ;
            {
                modify[x] = modifier(status[x]);
            }
        }

        private string genCharacter()
        {
            bool again = true;
            string name = "";
            char sex;
            int count = 0;
            Console.Write("(M)ale or (F)emale?");
            do
            {
                gender = Console.ReadLine();
                sex = Char.ToUpper(gender.FirstOrDefault());
                switch (sex)
                {
                    case 'M':
                        name = genMaleName();
                        again = false;
                        break;
                    case 'F':
                        name = genFemaleName();
                        again = false;
                        break;
                    default:
                        if (count < 2)
                            Console.Write("Please select either (M)ale or (F)emale.");
                        else if (count < 4 && count >= 2)
                            Console.Write("Select either (M)ale or (F)emale!");
                        else if (count == 4)
                        {
                            Console.WriteLine("You are now a female named Bob!");
                            name = "Bob";
                            gender = "female";
                            again = false;
                            newCharacterSelect = false;
                        }
                        break;
                }
                count++;
            } while (again);
            return name;
        }

        private string genMaleName()
        {
            string[] titleM = { "Sir ", "Mr. ", "Dr. ", "Sultan ", "Professor ", "Prince ", "King ", "Duke ", "Baron ", "Count " }

            string[] firstM = { "Uranius ", "Aloysius ", "Augustus ", "Octavius ", "Adolphus ", "Valerius ", "Heinrich ", "Amadeus ", "Severus ", "Wilhelm " }

            string[] middleName = { "P. ", "Q. ", "L. ", "Z. ", "W. ", "Y. ", "X. ", "E. ", "V. ", "U. " };

            string[] lastName = { "Clontarf ", "Knappogue ", "Bushmills ", "Jameson ", "Concannon ", "Carolans ", "Tyrconnell ", "Tullamore ", "Kilbeggan ", "McIvor " };

            string[] adjective = { "laughing ", "spitting ", "howling ", "frowning ", "smoking ", "grimacing ", "drooling ", "running ", "crying ", "fidgeting " };
            string[] animal = { "wolf ", "bumblebee ", "bulldog ", "cougar ", "emu ", "sea turtle ", "panda bear ", "mantis ", "okapi ", };
            string[] noun = { "masseuse.", "soother.", "shoe-shiner.", "therapist.", "tamer.", "whisperer.", "podiatrist.", "driver.", "sidekick.", "hero." };

            //random numbers to determine which index from array will be used
            int a = StaticRandom.Instance.Next(0, (titleM.Length));
            int b = StaticRandom.Instance.Next(0, (firstM.Length));
            int c = StaticRandom.Instance.Next(0, (middleName.Length));
            int d = StaticRandom.Instance.Next(0, (lastName.Length));
            int e = StaticRandom.Instance.Next(0, (adjective.Length));
            int f = StaticRandom.Instance.Next(0, (animal.Length));
            int g = StaticRandom.Instance.Next(0, (noun.Length));

            //concatenates pieces together to make name
            string name = titleM[a] + firstM[b] + middleName[c] + lastName[d] + "the " + adjective[e] + animal[f] + noun[g];

            return name;
        }

        private string genFemaleName()
        {
            string[] titleF = { "Madam ", "Ms. ", "Dr. ", "Sultana ", "Professor ", "Princess ", "Queen ", "Duchess ", "Baroness ", "Countess " };

            string[] firstF = { "Octavia ", "Augusta ", "Aurelia ", "Vivienne ", "Wilhelmina ", "Laetitia ", "Ludmilla ", "Briseis ", "Cleopatra ", "Ophelia " };

            string[] middleName = { "P. ", "Q. ", "L. ", "Z. ", "W. ", "Y. ", "X. ", "E. ", "V. ", "U. " };

            string[] lastName = { "Clontarf ", "Knappogue ", "Bushmills ", "Jameson ", "Concannon ", "Carolans ", "Tyrconnell ", "Tullamore ", "Kilbeggan ", "McIvor " };

            string[] adjective = { "laughing ", "spitting ", "howling ", "frowning ", "smoking ", "grimacing ", "drooling ", "running ", "crying ", "fidgeting " };
            string[] animal = { "wolf ", "bumblebee ", "bulldog ", "cougar ", "emu ", "sea turtle ", "panda bear ", "mantis ", "okapi ", };
            string[] noun = { "masseuse.", "soother.", "shoe-shiner.", "therapist.", "tamer.", "whisperer.", "podiatrist.", "driver.", "sidekick.", "hero." };


            int a = StaticRandom.Instance.Next(0, (titleF.Length));
            int b = StaticRandom.Instance.Next(0, (firstF.Length));
            int c = StaticRandom.Instance.Next(0, (middleName.Length));
            int d = StaticRandom.Instance.Next(0, (lastName.Length));
            int e = StaticRandom.Instance.Next(0, (adjective.Length));
            int f = StaticRandom.Instance.Next(0, (animal.Length));
            int g = StaticRandom.Instance.Next(0, (noun.Length));

            string name = titleF[a] + firstF[b] + middleName[c] + lastName[d] + "the " + adjective[e] + animal[f] + noun[g];

            return name;
        }

        private string genHis()
        {
            string[] from = { "the Vasyugan Swamp, ", "the Himalayan foothills, ", "a temple in Peru, ", "the French countryside, ", "the Berchtesgaden Alps, ", "the Carpathian Mountains, ", "the Bangweulu Swamps, ", "the Hoia Baciu Forest, ", "the Poveglia Island, ", "the Dargavs village, ", };
            string[] from2 = { "although it is often speculated by skeptics.", "but most are afraid to ask.", "unfortunately your birth records no longer exist.", "but you change the story to fit any given situation.", "which scares the hell out of children you cross.", "although you mostly tell people it isn't there business.", };
            int year = StaticRandom.Instance.Next(500, 20000);
            string[] exploit = { "Taming a werewolf to be your companion.", "Defeating an army of the undead with a swiss army knife.", "Organizing a following of gnomes to combat the uprising of giants.", "Infiltrating the kitchen at a vampire convention and serving pureed garlic.", "Drowning the Loch Ness Monster.", "Setting up Aobōzu on 'To Catch A Predator'", "Eliminating a Kraken using only drop kicks.", "Training a sled team of hellhounds...and winning three medals.", };


            int a = StaticRandom.Instance.Next(0, (from.Length));
            int b = StaticRandom.Instance.Next(0, (from2.Length));
            int c = StaticRandom.Instance.Next(0, (exploit.Length));

            string hist = "BirthPlace: Most people believe that you are originally from " + from[a] + from2[b] + "\n\n" + "Age: " + "The legends of your travels date back roughly " + year + " years. " + "\n\n" + "Your most infamous exploit: " + exploit[c];

            return hist;
        }

        public string getGender() { return gender; }
        public string getName() { return name; }
        public string getHistory() { return history; }

        public static playerClass newPlayer()
        {
            playerClass character = new playerClass();
            return character;
        }

        private void rollStats()
        {
            for (int i = 0; i < 6; i++)
            {
                int stat = 0;
                for (; stat < 12;)
                {
                    stat = dieRoller.totalRoll();
                }
                status[i] = stat;
            }

        }

        public void statUp(string stat, int add)
        {
            int i = 0;
            bool again = true;
            do
            {
                if (0 == (stat.CompareTo(statName[i])))
                {
                    status[i] = status[i] + add;
                    again = modSet();
                }
                else
                {
                    i++;
                }
                if (i > 5) { again = false; }
            } while (again);
        }

        public void printStat()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(statName[i] + ": " + status[i] + " + " + modify[i]);
            }
        }
    }
}
