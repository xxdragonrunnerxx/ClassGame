using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class inventory
    {
        private const int MaxInvSlot = 20;
        
        public List<object> playerInventory = new List<object>();

        public void AddItem(Item item)
        {
            if (playerInventory.Count < MaxInvSlot)
            {
                playerInventory.Add(new playerInventory(item));
            }

            else
            {
                throw new Exception("No more room");
            }
        }
    }
}
