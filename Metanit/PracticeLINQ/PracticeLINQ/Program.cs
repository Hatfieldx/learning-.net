using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace PracticeLINQ
{
   public class Car
    {
        public int[] Wheels { get; set; }
        public string PetName { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";

    }

    class Program
    {
        //what i should to do: 
        //++1. currentVideoGames выбрать без пробела и выбрать с цифрами исп сортировку. через линку и расширением
        //++2. Array и TupeOf - сделать Array данных и попробовать LINQ на нем
        //++3. отложенное выполнение и немедленное выполнение - попробовать использовать ToArray<T>, ToDictionary<TSource, ТКеу> () и ToList<T>
        //++4. возвратщение результата из запроса (создать метод, который будет объединять 2 коллекции и возвращать собранную)
        //++5. сделать проекцию к машинам с использованием selectMany (расширить машины какой-нить коллекцией)
        //++6. засунуть машины в Array и попробовать поработать с ним (не обобщенные коллекции)
        //++7. подсчет количества через LINQ - посчитать количество машин со скоростью больше 50
        //++8. реверс коллекции  - отобрать только черные машины и реверсировать выборку
        //++9. сделать примеры с myCars и yourCars: Except, Intersect, UnionO, Concat, Distinct
        //++10. примеры агрегирования с winterTemps: мин макс, авг, сумм
        //++11, разложить var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game; с использованием лямбда выражений


        static void Main(string[] args)
        {
            int numd = 5;

            //object o = numd;

            long ld = (long)numd;

            Console.WriteLine(ld);

            List<string> myCarsList = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var indexer = myCarsList.Select((u,i)=>new {Index = i, Name = u});

            foreach (var item in indexer)
            {
                Console.WriteLine($"index = {item.Index} ; name = {item.Name}");
            }

            Console.WriteLine(new String('=', 20));

            List<Car> myCars = new List<Car>() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW", Wheels = new int [] {3,4,5} },
                new Car{ PetName = "Daisy", Color = "Black", Speed = 90, Make = "BMW", Wheels = new int [] {3,4,5} },
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW", Wheels = new int [] {3,4,5} },
                new Car{ PetName = "Clunker", Color = "Black", Speed = 5, Make = "Yugo", Wheels = new int [] {13,4,5} },
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford", Wheels = new int [] {53,4,5} }
            };

            var carsov = myCars.Select(u => new { car = u, maxWheels = u.Wheels.Max() }).OrderByDescending(u=>u.maxWheels).First();


            Console.WriteLine(carsov.car.PetName);

            Console.WriteLine(new String('=', 20));

            List<Car> myCars1 = new List<Car>() {
                new Car{ PetName = "Alice", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            var maxi = winterTemps.Max();
            var mini = winterTemps.Min();
            var sum = winterTemps.Sum();

            //var maxL = (from temp in winterTemps select temp).;

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Task gameSearchNoSpace = Task.Factory.StartNew(() => {

                var gamesNoSpace = from game in currentVideoGames where !(game.Contains(" ")) orderby game select game;

                foreach (var item in gamesNoSpace)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("task gameSearchNoSpace stopped");
            });            

            gameSearchNoSpace.ContinueWith(
                (Task t) =>
                {
                    Console.WriteLine("second task started");

                    t = Task.Factory.StartNew(() =>
                    {
                        var gamesWhithNum = from game in currentVideoGames let gt = IncludeNum(game) where gt orderby game select game;

                        bool IncludeNum(string s)
                        {
                            Regex filter = new Regex(@"\d");

                            MatchCollection mc = filter.Matches(s);

                            return mc.Count > 0;
                        }

                        foreach (var item in gamesWhithNum)
                        {
                            Console.WriteLine(item);
                        }
                    });

                    t.Wait();
                    Console.WriteLine("second task stopped");                    
                }).Wait();

            Console.WriteLine(new String('-', 10));

            Queue q = new Queue();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue('a');

            IEnumerable<int> g = q.OfType<int>();

            var a = (from i in g select i).ToList();

            Console.WriteLine(new String('-', 10));

            var newColl = GetNewColl(myCars, myCars1, new Ecual());

            foreach (var item in newColl)
            {
                Console.WriteLine($"{item.PetName} {item.Color} {item.Speed}");
            }

            Console.WriteLine(new String('-', 10));

            var proection = from car in myCars let sv = $"{car.Make}  - changed" select new {Name = car.PetName, Speed = car.Speed + 50, Vendor = "China", SomeVarible = sv };

            foreach (var item in proection)
            {
                Console.WriteLine($"{item.Name} {item.Speed} {item.Vendor} {item.SomeVarible}");
            }

            // Console.WriteLine((from j in myCars where j.Speed>50 select j).Count());

            Console.WriteLine(myCars.Where(j=> j.Speed > 50).Count());

            foreach (var item in myCars.Where(j => j.Color == "Black").Reverse())
            {
                Console.WriteLine($"{item.PetName}");
            }

            Console.WriteLine(new String('-', 10));

            var maxWheels = myCars.SelectMany(l => l.Wheels, (l, u) => new { car = l, maxWheels = u }).Max(l => l.maxWheels);

            var carMaxWheels = myCars.SelectMany(l => l.Wheels, (l, u) => new { car = l, maxWheels = u }).Where(h=>h.maxWheels == maxWheels).Select(l=>l.car).First();

            Console.WriteLine(carMaxWheels.PetName);
            // .Select(k=>k.car);

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };

            var res = nums.TakeWhile(x => x < 6);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new String('-', 10));

            //var emptyCol = Enumerable.Empty<int>();

            //var first = nums.Single();

            nums.AsParallel().Select(i=>i).ForAll(i => Console.WriteLine(i));

            Console.WriteLine(new String('=', 10) + "try factorial");

            object[] testEx = { 7, 8, 3, 12, 45, 12, 87 };

            CancellationTokenSource cts = new CancellationTokenSource();

            cts.CancelAfter(1000);

            try
            {
                (from num in testEx
                             .AsParallel().WithCancellation(cts.Token)
                 select (int)num).ForAll(x => Console.WriteLine($"Factorial {x} = {Factorial(x)}"));
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операция отменена токеном");

            }

            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }

            finally
            {
                cts.Dispose();
            }

            Console.ReadKey();
        }

        private static List<Car> GetNewColl(List<Car> myCarsList, List<Car> yourCars, IEqualityComparer<Car> comparer)
        {
            //Except, Intersect, UnionO, Concat, Distinct
            // return (myCarsList.Concat(yourCars, comparer)).ToList();
            return (myCarsList.Concat(yourCars)).ToList();
        }

        private static double Factorial(int x)
        {
            double res = 1;

            if (x == 0)
            {
                return 1;
            }

            for (int i = 1; i <= x; i++)
            {
                res *= i;
            }

            Thread.Sleep(20000);

            return res;
        }
    }

    class Ecual : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            if (x == null || y == null)
            {
                throw new NullReferenceException();
            }

            return x.PetName == y.PetName;            
        }

        public int GetHashCode(Car obj)
        {
            return 1;
        }
    }

}
