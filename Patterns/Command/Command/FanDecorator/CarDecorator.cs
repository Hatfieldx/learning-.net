using System;

namespace Command.FanDecorator
{
    abstract class CarDecorator : Car
    {
        protected Car extObject;

        public virtual void GetPriceAdd()
        {
            price *= WheelsCount;

            Console.WriteLine($"My price is {Price}");
        }

        public virtual void DriveAdd()
        {
            Console.WriteLine($"I'm {Model}, can Drive");
        }

        public CarDecorator(string model, int wheels, Car car) : base(model, wheels)
        {
            Model = $"This car {Model} ubgraded {car.Model}";
        }
    }
}
