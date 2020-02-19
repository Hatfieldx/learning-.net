using Prototype.IncapsulateActions;
using Prototype.People;
using System;
using System.Collections.Generic;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>() {

            new Dog("Lokki", 1, 20),

            new Horse("LOSHADKA", 1, 20),

            new Camel("VERBLUDE", 1, 20)
        };

            foreach (IAnimal animal in animals)
            {
                animal.Move();
                animal.Shout();
                animal.Walk();

                Console.WriteLine(new string('=', 20));
            }

            //change dog behavior 
            animals[0].actionsource = new HorseActions();

            Console.WriteLine(animals[0].ToString()); 
            
            animals[0].Move();
            animals[0].Shout();
            animals[0].Walk();

            Console.WriteLine(new string('=', 20));

            IAnimalOwner doctor = new Doctor() {Name = "Doc", Age = 34, Animal = animals[1] };

            IAnimalOwner copyDoc = (IAnimalOwner)doctor.Clone();

            Console.WriteLine(new string('=', 20) + "BEFORE");

            doctor.PrintPet();
            copyDoc.PrintPet();

            copyDoc.Animal.Name = "LUSKA!!!";

            Console.WriteLine(new string('=', 20) + "AFTER");

            doctor.PrintPet();
            copyDoc.PrintPet();

            Console.ReadKey();
        }
    }
}
