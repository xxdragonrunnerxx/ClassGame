using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    public abstract class ObtainableItem
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int maxInaStack { get; set; }

        protected ObtainableItem()
        {
            maxInaStack = 1;
        }
    }
}
