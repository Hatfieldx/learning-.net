using System;

namespace Factory
{
    abstract class Animal : IAnimal
    {
        public string Name { get; set; }

        public virtual void Move()
        {
            Console.WriteLine("I Moving");
        }

        public Animal(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
