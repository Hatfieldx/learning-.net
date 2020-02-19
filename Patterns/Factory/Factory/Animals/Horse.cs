using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    class Horse:Animal
    {
        public override void Move()
        {
            Console.WriteLine("Horse moving");
        }

        public Horse(string name) : base(name)
        {

        }
    }
}
