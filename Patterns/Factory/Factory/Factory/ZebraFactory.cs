using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Factory
{
    class ZebraFactory : AnimalFactory
    {
        public override Animal GetAnimal()
        {
            return new Zebra("I Zebra!!");
        }
    }
}
