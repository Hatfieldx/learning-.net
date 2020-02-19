using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Factory
{
    class HorseFactory : AnimalFactory
    {
        public override Animal GetAnimal()
        {
            return new Horse("I Horse");
        }
    }
}
