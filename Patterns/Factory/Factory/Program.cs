using System;
using System.Collections.Generic;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>
            {
                new Factory.DogFactory().GetAnimal(),
                new Factory.HorseFactory().GetAnimal(),
                new Factory.ZebraFactory().GetAnimal()
            };

            foreach (IAnimal item in animals)
            {
                item.Move();
            }

            Console.ReadKey();
        }
    }
}
