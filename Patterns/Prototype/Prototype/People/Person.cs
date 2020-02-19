using System;

namespace Prototype
{
    [Serializable]
    abstract class Person: IPerson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"HUMAN {Name} - {Age}");
        }
    }
}
