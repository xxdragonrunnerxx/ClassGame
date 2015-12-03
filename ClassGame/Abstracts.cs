using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{

    abstract class building
    {
        //Abstract class for any building 
        int Height { get; set; }
        int Width { get; set; }
        int NumRooms { get; set; }
        Person Owner { get; set; }

        //Constructor for building
        protected building(int height, int width, int numRooms, Person owner)
        {
            Height = height;
            Width = width;
            NumRooms = numRooms;
            Owner = owner;

        }

        //Function to display information about any building
        public override string ToString()
        {
            return string.Format("Height: {0} \nWidth: {1} \nNumber of Rooms: {2} \nOwner: {3}", Height, Width, NumRooms, Owner.Name);
        }
    }

    //abstract class for business with building base
    abstract class business : building
    {
        int Height { get; set; }
        int Width { get; set; }
        int NumRooms { get; set; }
        Person Owner { get; set; }

        //constructor for business with building base
        protected business(int height, int width, int numRooms, Person owner) : base(height, width, numRooms, owner)
        {
            Height = height;
            Width = width;
            Owner = owner;
            NumRooms = numRooms;
        }

        //A general greeting for any business that doesn't override
        public virtual void Greetings()
        {
            Console.WriteLine("Welcome to my Shop");
        }

    }

    interface IShop
    {
        void buyItem(equipItem i);
        void buyConsumable(consumable c);
        void showInventory();
        void Mingle();
    }

}
