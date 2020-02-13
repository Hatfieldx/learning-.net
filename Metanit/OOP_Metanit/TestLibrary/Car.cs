using System;


namespace TestLibrary
{
   public class Car
    {
        readonly int Sam;
        public static int EngineCount { get; set; }
        public string Model { get; set; }

        public string Vendor { get; set; }

        public int WheelCount { get; set; }

        public Car(string mod, string vend, int wheels)
        {
            Model = mod;
            Vendor = vend;
            WheelCount = wheels;

            Sam = 5;
        }

        public void Inf()
        {
           // Sam = 9;

        }

        public static bool operator > (Car firstCar, Car secondCar)
        {
            return firstCar.WheelCount > secondCar.WheelCount;
        }

        public static bool operator < (Car firstCar, Car secondCar)
        {
            return firstCar.WheelCount < secondCar.WheelCount;
        }

        public static int Mov(params int[] a)
        {
            int res = 0;

            foreach (int item in a)
            {
                res += item;
            }

            return res;
        }
    }
}
