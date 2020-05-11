using System;

namespace Command.FanDecorator
{
    class BatmanCarDecorate : CarDecorator
    {

        public BatmanCarDecorate(string model, int wheels, Car car) : base(model, wheels, car)
        {

        }

        public override void Drive()
        {
            
        }

        public override void GetPrice()
        {
            
        }
    }
}
