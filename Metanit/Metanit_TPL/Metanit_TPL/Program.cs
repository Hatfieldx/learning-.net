using System;
using System.Threading;
using System.Threading.Tasks;

namespace Metanit_TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(() => {
            //    Console.WriteLine("Task started");

            //    DateTime currentWithMin = DateTime.Now.AddSeconds(5);

            //    while (currentWithMin > DateTime.Now)
            //    {
            //        Console.WriteLine($"Doing {Task.CurrentId}");
            //    }

            //    Console.WriteLine("Task stopped");
            //});

            //t.Start();
            //t.Wait();

            //3 способа создания таски

            //Task t4 = Task.Factory.StartNew(() =>
            //{
            //    Task t5 = Task.Factory.StartNew(() => { Console.WriteLine("Task5"); }, TaskCreationOptions.AttachedToParent);
            //    t5.Wait();
            //    Console.WriteLine("Task4");
            //});

            //t4.Wait();

            //Task t1 = new Task(() => { Console.WriteLine("Task1"); });

            //t1.Start();
            ////t1.Wait();

            //Task t2 = Task.Factory.StartNew(()=> { Console.WriteLine("Task2"); });
            ////t2.Wait();



            //Task t3 = Task.Run(() => { Console.WriteLine("Task3"); });
            ////t3.Wait();

            //Task[] tasks =
            //    {
            //    new Task<int>(() => { Console.WriteLine("Task1"); return 1; }),
            //    new Task(() => { Console.WriteLine("Task2"); }),
            //    new Task(() => { Console.WriteLine("Task3"); }),
            //    new Task(() => { Console.WriteLine("Task4"); }),
            //    new Task(() => { Console.WriteLine("Task5"); }),
            //};

            //for (int i = 0; i < tasks.Length-1; i++)
            //{
            //    tasks[i].Start();
            //}

            //Task<int> t_int = tasks[0] as Task<int>;

            //int f = t_int.Result;

            //Console.WriteLine(f);

            //Task.WaitAll(tasks);

            CancellationTokenSource tokenFactory = new CancellationTokenSource();

            CancellationToken token1 = tokenFactory.Token;

            CancellationToken token2 = tokenFactory.Token;

            Console.WriteLine($"{token1} hash code {token1.GetHashCode()}");
            Console.WriteLine($"{token2} hash code {token2.GetHashCode()}");

            Console.ReadKey();

            ParallelLoopState p = null;
                                 
            try
            {
                Parallel.For(1, 10, new ParallelOptions() { CancellationToken = token1 }, TestParallel);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("canceled by token");
            }

            finally
            {
                tokenFactory.Dispose();
            }

            

            tokenFactory.Cancel();

            Console.WriteLine("Main is stopped");

            Console.ReadKey();
        }

        static void TestParallel(int x, ParallelLoopState p)
        {
            //if (!(x == 1))
            //{
            //    Console.WriteLine("break");
            //    p.Break();
            //}
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);

            //Console.WriteLine($"{Task.CurrentId} index of cycle {x}");
        }

        static void TestTask()
        {
            DateTime currentWithMin = DateTime.Now.AddMinutes(3);

            while (currentWithMin > DateTime.Now)
            {
                Console.WriteLine($"Doing {Task.CurrentId}");
            }
        }
    }
}
