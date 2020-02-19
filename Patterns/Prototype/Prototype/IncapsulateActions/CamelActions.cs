using System;

namespace Prototype.IncapsulateActions
{
    class CamelActions:AnimalActions
    {
        public override void Shout()
        {
            Console.WriteLine("CAMEL IS SHOUTING!!");
        }

        public override void Walking()
        {
            //camels doesnt walk
        }
    }
}
