using System;
using System.Reflection;
using CarsPro;
	

	

namespace DoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            Type mtype = typeof(Car);

            Type mytype2 = Type.GetType("CarsPro.LadaSedan,Cars", false, true);

            Car newCar = new LadaSedan("model1", "red", 3, "Lada");

            if (mytype2 == newCar.GetType())
            {
                Console.WriteLine("types is equal!!!");
            }

            MemberInfo[] mInfo = mytype2.GetMembers();

            foreach (var item in mInfo)
            {
                Console.WriteLine($"{item.DeclaringType} {item.MemberType} {item.Name}");
            }

            Console.ReadKey();
        }
    }
}
