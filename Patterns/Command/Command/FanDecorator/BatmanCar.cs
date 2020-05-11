using System;

namespace Command.FanDecorator
{
    class BatmanCar : Car
    {
        public override void GetPrice()
        {
            Console.WriteLine($"My price is  {Price}");
        }

        public override void Drive()
        {
            Console.WriteLine("I'm Batman car, can faster Drive and Fly!");
        }

        public BatmanCar(string model, int wheels) : base(model, wheels)
        {
            
        }
    }
}
