using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    class Dog:Animal
    {
        public override void Move()
        {
            Console.WriteLine("Dog moving");
        }

        public Dog(string name):base(name)
        {

        }
    }
}
