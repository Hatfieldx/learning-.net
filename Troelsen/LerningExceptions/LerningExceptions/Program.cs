using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LerningExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('=', 20) + "FUN with observamle list");


            ObservableCollection<Car> obsCar = new ObservableCollection<Car>()
            {
                new SportCar("A", "B"),
                new SportCar("D", "E"),
                new SportCar("S", "F"),
                new SportCar("V", "W"),
                new SportCar("K", "G")
            };

            obsCar.CollectionChanged += (obj, args) => Console.WriteLine("obs car changed");

            obsCar.Add(new SportCar("K", "G"));



            Console.WriteLine(new string('=', 20) + "FUN with sorted list");
            
            Garage garage = new Garage();

            garage.Add(new SportCar("A", "B"));
            garage.Add(new SportCar("D", "E"));
            garage.Add(new SportCar("S", "F"));
            garage.Add(new SportCar("V", "W"));
            garage.Add(new SportCar("K", "G"));

            SortedSet<Car> sortedCar = new SortedSet<Car>(new CarComparer())
            {
                new SportCar("A", "B"),
                new SportCar("D", "E"),
                new SportCar("S", "F"),
                new SportCar("V", "W"),
                new SportCar("K", "G")
            };

            foreach (var item in sortedCar)
            {
                Console.WriteLine(item.Model);
            }

            Console.WriteLine($"lada {garage[3].GetHashCode()} - {garage[3].Model} - {garage[3].Factory}");

                     
            
            garage[3] = new SportCar("D", "E");

            var res = new Predicate<Car>((Car x)=>x.Model == "A").Invoke(new SportCar("A", "E"));

            Console.WriteLine($"sport car {res} {garage[3].Model} != A");

            Console.WriteLine($"lada {garage[3].GetHashCode()} - {garage[3].Model} - {garage[3].Factory}");

            garage.ExtMethod();

            //Console.WriteLine($"lada {garage[6].GetHashCode()} - {garage[6].Model} - {garage[6].Factory}");

            foreach (Car item in garage)
            {
                Console.WriteLine($"{item.Model}-{item.Factory}");
            }

            SportCar bmw = new SportCar("A", "B");

            SportCar lada = (SportCar)bmw.Clone();

            Console.WriteLine($"lada {lada.GetHashCode()} - {lada.Model} - {lada.Factory}");

            Console.WriteLine($"bmw {bmw.GetHashCode()} - {bmw.Model} - {bmw.Factory}");


            Console.ReadKey();
        }
    }
}
