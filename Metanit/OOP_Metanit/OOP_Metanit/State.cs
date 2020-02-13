using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Metanit
{
    class State
    {
        public decimal Population { get; set; }
        public decimal Area { get; set; }

        public static bool operator > (State a, State b)
        {
            return a.Population > b.Population;
        }
        public static bool operator < (State a, State b)
        {
            return a.Population < b.Population;
        }
        public static State operator + (State a, State b)
        {
            return new State() { Population = a.Population + b.Population, Area = a.Area + b.Area };
        }

        public static void GetInfo(State a)
        {
            Console.WriteLine($"Population = {a.Population}, Area = {a.Area}");
        }

    }
}
