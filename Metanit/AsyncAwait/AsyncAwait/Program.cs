using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "Dermatoglyphics";

            string pattern = "abcdefghijklmnopqrstuvwxyz";

            bool isIsogram = true;

            Dictionary<char, int> voc = new Dictionary<char, int>();

            foreach (char item in s)
            {
                if (pattern.Contains(item))
                {
                    if (voc.ContainsKey(item))
                    {
                        isIsogram = false;
                        break;
                    }
                    else
                        voc.Add(item, 1);
                }
            }

            Console.WriteLine($"isIsogram \"{s}\" == {isIsogram}");


            Task<int> t = SolverAsync();

            Console.WriteLine("Enter number: ");

            bool isParsed = Int32.TryParse(Console.ReadLine(), out int number);

            if (isParsed)
            {
                Console.WriteLine($"квадрат числа {number} равен {number * number}");
            }

            t.Wait();            

            Console.WriteLine("Main finished");

            Console.WriteLine(t.IsCompleted);

            Console.WriteLine(t.Result);

            Console.ReadLine();
        }

        static async Task<int>  SolverAsync()
        {
            DateTime dt = DateTime.Now.AddSeconds(20);

            int x = await Task.Factory.StartNew(() => {

                Console.WriteLine("Async started");

                while (dt > DateTime.Now)
                {

                }

                Console.WriteLine("Async completed");
                return 45;
            });

            return x;
        }
    }
}
