using System;
using System.Collections.Generic;
using System.Text;

namespace Single
{
    class SimpleSingletone
    {
        string name;
        
        static SimpleSingletone instance;
        public static string SomeText { get; set; }

        public static SimpleSingletone Current(string name)
        {
            if (instance == null)
            {
                instance = new SimpleSingletone(name);
            }           

            return instance;
        }
        
        private SimpleSingletone(string name)
        {
            this.name = name;
            
            Console.WriteLine("Ctor has worked");
            Console.WriteLine(DateTime.Now);
        }

        public void PrintName() => Console.WriteLine(name);
    }
}
