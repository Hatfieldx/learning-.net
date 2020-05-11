using System;


namespace Command.FanDecorator
{
    class SportLadaSedan : Car
    {
        public override void GetPrice()
        {
            Console.WriteLine($"My price is  {Price}");
        }

        public override void Drive()
        {
            Console.WriteLine("I'm Sport Lada Sedan, can faster Drive");
        }

        public SportLadaSedan(string model, int wheels) : base(model, wheels)
        {
        }
    }
}
