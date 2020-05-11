using System;
using System.Collections.Generic;
using System.Text;

namespace Command.FanDecorator
{
    abstract class Car
    {
        protected int price;        
        
        public string Model { get; set; }

        public int WheelsCount { get; set; }

        public int Price { get => price; }

        public abstract void GetPrice();

        public abstract void Drive();

        public Car(string model, int wheels)
        {
            Model = model;
            WheelsCount = wheels;
        }
    }
}
