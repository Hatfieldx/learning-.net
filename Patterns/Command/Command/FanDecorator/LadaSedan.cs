using System;

namespace Command.FanDecorator
{
    class LadaSedan : Car
    {
        public override void GetPrice()
        {       
            Console.WriteLine($"My price is {Price}");
        }

        public override void Drive()
        {
            Console.WriteLine("I'm Lada Sedan, can Drive");
        }

        public LadaSedan(string model, int wheels) : base(model, wheels)
        {
            price = 100;
        }
    }
}
