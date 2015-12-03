using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    // Item limit of 20
    // consumables are stackable up to 15... for now
    // drop items and destroys (maybe)
    
    public class inventorySystem
    {
        private const int maxItemslots = 20;

        public readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();

        public void AddItem(ObtainableItem item, int quantityToAdd)
        {
            while (quantityToAdd > 0)
            {
                
            }
        }

        public class InventoryRecord
        {
            public ObtainableItem InventoryItem { get; private set; }
            public int Quantity { get; private set; }

            public InventoryRecord(ObtainableItem item, int quantity)
            {
                InventoryItem = item;
                Quantity = quantity;
            }

            public void AddToQuantity(int amountToAdd)
            {
                Quantity += amountToAdd;
            }
        }
    }
}
