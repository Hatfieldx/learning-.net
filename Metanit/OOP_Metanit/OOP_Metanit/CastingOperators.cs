using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Metanit
{
    class CastingOperators
    {
    }

    class Clock
    {
        public int Hours { get; set; }

        public static implicit operator Clock (int perem)
        {
            return new Clock() {Hours = perem%24 };
        }

        public static explicit operator int (Clock perem)
        {
            return perem.Hours;
        }
    }

    class Celcius
    {
        public double Gradus { get; set; }

        public static implicit operator Celcius(Fahrenheit perem)
        {
            return new Celcius() { Gradus = 5.0 / 9.0 * (perem.Gradus-32) };
        }

        //public static explicit operator Celcius(Fahrenheit perem)
        //{
        //    return new Celcius() { Gradus = perem % 24 };
        //}
    }
    class Fahrenheit
    {
        public double Gradus { get; set; }

        public static implicit operator Fahrenheit(Celcius perem)
        {
            return new Fahrenheit() { Gradus = 9.0 / 5.0 * (perem.Gradus + 32) };
        }
    }

    class Dollar
    {
        public decimal Sum { get; set; }

        public static implicit operator Dollar(Euro perem)
        {
            return new Dollar() { Sum = 1.4m * perem.Sum };
        }
    }
    class Euro
    {
        public decimal Sum { get; set; }

        public static implicit operator Euro(Dollar perem)
        {
            return new Euro() { Sum = perem.Sum / 1.4m };
        }
    }
}
