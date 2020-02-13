using System;
using System.Collections.Generic;
using System.Text;

namespace CarsPro
{
    public abstract class Car : ICar
    {
        public int WheelsCount { get; set; }
        public string Color { get; set; }
        public string ModelName { get; set; }
        public string Factory { get; set; }


        public virtual void Move()
        {
            Console.WriteLine("Move");
        }

        public virtual void ViewInfo()
        {
            Console.WriteLine($"I car {ModelName} with wheels {WheelsCount} by {Factory}. My color is {Color}");
        }

        protected Car(string model, string color, int wheelsCount, string factory)
        {
            ModelName = model;

            Color = color;

            WheelsCount = wheelsCount;

            Factory = factory;
        }
    }
    [WheelsCount(4)]
    public class LadaSedan:Car
    {
        int PrivateProp { get; set; }

        int privateField = 14;

        public LadaSedan(string model, string color, int wheelsCount, string factory)
            :base(model, color, wheelsCount, factory)
        {

        }

        public override void Move()
        {
            Console.WriteLine("Danger! It is moving LADA SEDAN");
        }

        private void PrivateMove()
        {
            Console.WriteLine("Danger! It is moving LADA SEDAN____PRIVATE");
        }

        public override void ViewInfo()
        {
            base.ViewInfo();
        }
    }
    [WheelsCount(4)]
    public class BMW : Car
    {
        public BMW(string model, string color, int wheelsCount, string factory)
            : base(model, color, wheelsCount, factory)
        {

        }

        public override void Move()
        {
            Console.WriteLine("get like, im a BMW");
        }

        public override void ViewInfo()
        {
            base.ViewInfo();
        }
    }
}
