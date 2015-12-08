using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    [Serializable]
    class Story
    {

        public static string[] TheStory = new string[30];
        public static string[] newStory()
        {

            //Opening Forest
            TheStory[0] = ("You find yourself in a forest with nothing more than the clothes on your back. \nYou don't remember how you got to be here or what happened to your equipment. \n\nObjective: Find your way out of the forest.");

            //Starting Town
            TheStory[1] = ("You stumble out of the forest and into a town. \n\nObjective: Explore town before starting on your adventure.");

            //Forest
            TheStory[2] = ("You are now on your way. This path will lead you to a ghastly place where lost souls linger. \n\nObjective: Be sure you're ready before you continue.");

            //Castle
            TheStory[3] = ("You step inside the castle into a large foyer. \nStrange noises echo from through the halls. \nBats hang from the chandelier on the ceiling above you. \n\nObjective: Find the Stairs. ");
            TheStory[4] = ("");
            TheStory[5] = ("");
            TheStory[6] = ("");
            TheStory[7] = ("");
            TheStory[8] = ("");
            TheStory[9] = ("");
            TheStory[10] = ("");
            TheStory[11] = ("");
            TheStory[12] = ("");
            TheStory[13] = ("");
            TheStory[14] = ("");
            return TheStory;
        }
        public static string getStory(int x)
        {
            return TheStory[x];
        }

//forest 
//town
//forest
//leap castle (5)
//graveyard (2)
//Forest
//town//
//japanese forest(5)
//creek level
//town//
//castle (2)
//catacomb(4)//


    }
}
