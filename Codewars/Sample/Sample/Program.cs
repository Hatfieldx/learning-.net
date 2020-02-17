using System;
using System.Linq;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //long m = 1071225L;

            ////  Console.WriteLine(findNb(m));

            //int[][] x = new int[][] { new int[] { 18, 20 }, new int[] { 45, 2 }, new int[] { 61, 12 }, new int[] { 37, 6 }, new int[] { 21, 21 }, new int[] { 78, 9 } };

            //var res = x.Select((x) =>
            //{
            //    if (x[0] >= 55 && x[1] > 7)
            //        return "Senior";
            //    else
            //        return "Open";
            //});


            //4. Сравнение и конкатенация строк.

            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);

           // System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);

            Console.WriteLine("{0:d8}", 342343);
            Console.WriteLine(string.Format("{0,15:c3}", 1256));

            Console.WriteLine("{0, 10:F}",new DateTime(2020, 2, 10));

            Console.WriteLine("now is {0, 10:f}", DateTime.Now.AddMinutes(-15));

            Nullable<int> x = null;

            int y = x ?? 0;

            var t = (Name: "name", Age: 13 );

            var at = new { Name = "Niko", Age = 34 };

            Console.WindowWidth = 200;

            Console.WriteLine(new string('=', 20));

            Console.WriteLine($"tuple: {t.GetType()}, anonim class: {at.GetType()}");

            Console.WriteLine(new string('=', 20));

            string s = t.Name;

           // (string, _) t4 = t;



            Console.WriteLine(t.GetType());

            (string Name, int Age) t2 = ("Nik", 43);

            Console.WriteLine($"before {t2}");
            
            ChangeTuple(ref t2);

            Console.WriteLine($"after {t2}");

            string s2 = t2.Name;
            
            Console.WriteLine($"{x??32} -  {y}");

            Console.WriteLine(new string('=',20));

            Person p = new Person("Iban", 33);

            p.PringInfo();

            Console.ReadKey();
        }

        private static void ChangeTuple(ref (string Name, int Age) t2)
        {
            t2 = ("Serg", 55);
        }

        private static long findNb(long m)
        {
            long temp = 0L;

            int counter = 0;

            while (m>temp)
            {
                temp += (long)System.Math.Pow(++counter, 3);
            }

            return (m == temp) ? counter : -1; 
        }
    }
}
