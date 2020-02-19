using System;

namespace Single
{
    class LazySingle
    {
        public readonly string name;
        
        static Lazy<LazySingle> instance = new Lazy<LazySingle>(()=>new LazySingle("goot single"));

        public LazySingle Current { get => instance.Value; }

        private LazySingle(string n)
        {
            name = n;

            Console.WriteLine($"Lazy ctor by name {n}");
        }
    }
}
