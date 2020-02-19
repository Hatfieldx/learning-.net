using System;


namespace Factory
{
    abstract class AnimalFactory : IAnimalFactory
    {
        public abstract Animal GetAnimal();
    }
}
