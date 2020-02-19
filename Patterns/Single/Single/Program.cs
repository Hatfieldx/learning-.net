using System;
using System.Threading;
using System.Threading.Tasks;

namespace Single
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Реализовать простой сингл тон

            //2. Реализовать потокобезопасный синглтон через лок

            //5. Реализовать синглтон с исп Lazy<>

            SimpleSingletone.SomeText = "test";

            Task.Factory.StartNew(() =>
            {
                SimpleSingletone s4 = SimpleSingletone.Current("s4 task");

                Thread.Sleep(2000);

                s4.PrintName();
            });

            SimpleSingletone s = SimpleSingletone.Current("s");            

            SimpleSingletone s1 = SimpleSingletone.Current("s1");

            SimpleSingletone s2 = SimpleSingletone.Current("s2");

            SimpleSingletone s3 = SimpleSingletone.Current("s3");

            //SimpleSingletone t = Task.Factory.StartNew(()=>SimpleSingletone.Current()).Result;        
            
            Console.WriteLine($"{s.GetHashCode()} \n{s1.GetHashCode()} \n{s2.GetHashCode()} \n{s3.GetHashCode()}");

            s.PrintName();
            s1.PrintName();
            s2.PrintName();
            s3.PrintName();
           // x.PrintName();

            Console.ReadKey();
        }
    }
}
