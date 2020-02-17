using System;

namespace LerningExceptions
{
    class Radio : IRadio
    {
        RadioStatus currentstatus;

        public double Frequency { get; set; }

        public RadioStatus currentStatus => currentstatus;

        public string Caption { get; set; }

        public void Play()
        {
            currentstatus = RadioStatus.Playing;
            Console.WriteLine("Radio is playing");
        }

        public void CarSpeedHandler(Car car, CarEventArguments args)
        {
            Console.WriteLine($"Radio is storred bcz car {car.Model} speed is max {car.MaxSpeed}!!!");
            currentstatus = RadioStatus.Muted;
        }

        public Radio(double freq, string caption)
        {
            Frequency = freq;
            Caption = caption;
        }
    }
}
