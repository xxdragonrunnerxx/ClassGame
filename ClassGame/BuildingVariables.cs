using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    class Person
    {
        public string Name { get; set; }
        public string Story { get; set; }

        public Person(string name, string story)
        {
            Name = name;
            Story = story;
        }
    }
}
