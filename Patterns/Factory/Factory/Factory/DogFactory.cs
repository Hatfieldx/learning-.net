using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Factory
{
    class DogFactory : AnimalFactory
    {
        public override Animal GetAnimal()
        { 
            return new Dog("I Dog!");
        }
    }
}
