
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LerningExceptions
{
    delegate void CarEventHandler(object o, CarEventArguments args);
    
    abstract class Car //: ICar
    {
        event CarEventHandler StartEvent;
        event CarEventHandler StopEvent;

        CarStatus currentStatus;
        int currentspeed;
        protected int maxspeed;

        public string Model { get; set; }
        public string Factory { get; set; }
        public int MaxSpeed => maxspeed;

        public int CurrentSpeed => currentspeed;

        public CarStatus CurrentStatus => currentStatus;

        private void HandlersInvoke(CarEventHandler carevent, string message)
        {
            carevent?.Invoke(this, new CarEventArguments(message));
        }

        public virtual void Start()
        {
            currentStatus = CarStatus.Moving;

            HandlersInvoke(StartEvent, $"Машинка {Model} - {Factory} - {MaxSpeed} поехала");

        }

        public virtual void Stop()
        {
            currentStatus = CarStatus.Stopped;
            currentspeed = 0;

            HandlersInvoke(StopEvent, $"Машинка {Model} - {Factory} - {MaxSpeed} остановилась");
        }

        public Car(string model, string factory)
        {
            Model = model;
            Factory = factory;
        }
    }

    class SportCar:Car, ICloneable, IComparable<SportCar>
    {
        System.Lazy<Radio> radio = new Lazy<Radio>(()=> new Radio(1234, "SportCarRadio"));
        
        public Radio CarRadio {get => radio.Value;}

        public SportCar(string model, string factory) :base(model, factory)
        {
            maxspeed = 120;   
        }

        public object Clone()
        {
            return new SportCar(this.Model, this.Factory);
        }

        public int CompareTo(SportCar car)
        {
            if (car!=null)
            {
                if (this.MaxSpeed > car.MaxSpeed)

                    return 1;

                else if (this.MaxSpeed == car.MaxSpeed)

                    return 0;

                else
                    
                    return -1;
            }

            throw new NullReferenceException("неправильный параметрб сорян");
        }
    }

    class SlowCar : Car
    {        
        public SlowCar(string model, string factory):base(model, factory)
        {
            maxspeed = 60;
        }
    }

    class CarComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            if (x != null && y != null)
            {
                return string.Compare(x.Model, y.Model);
            }

            throw new NullReferenceException("неправильный параметры сорян");
        }
    }

}
