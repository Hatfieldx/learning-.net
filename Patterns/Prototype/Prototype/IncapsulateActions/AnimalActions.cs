using System;

namespace Prototype
{
    [Serializable]
    abstract class AnimalActions : IAnimalAction
    {
        public virtual void Move()
        {
            Console.WriteLine("animal is moving");
        }

        public virtual void Shout()
        {
            Console.WriteLine("animal is shouting");
        }

        public virtual void Walking()
        {
            Console.WriteLine("animal is walking");
        }
    }
}
