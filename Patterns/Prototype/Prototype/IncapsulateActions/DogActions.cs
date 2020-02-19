using System;

namespace Prototype.IncapsulateActions
{
    class DogActions : AnimalActions
    {
        public override void Shout()
        {
            Console.WriteLine("DOG IS SHOUTING!! GAW GAW");
        }
    }
}
