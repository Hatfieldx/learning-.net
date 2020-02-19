using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    class Zebra: Animal
    {
        public override void Move()
        {
            Console.WriteLine("Zebra moving");
        }

        public Zebra(string name) : base(name)
        {

        }
    }
}
