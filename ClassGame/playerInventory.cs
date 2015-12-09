using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class playerInventory
    {
        public Item inventoryItem { get; set; }

        public playerInventory(Item item)
        {
            inventoryItem = item;
        }
    }
}
