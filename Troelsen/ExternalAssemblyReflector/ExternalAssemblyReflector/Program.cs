using System;
using System.Reflection;
using System.Linq;


namespace ExternalAssemblyReflector
{
    class Program
    {
        static void Main(string[] args)
        {
            string asmName = @"D:\EDU_C#\Metanit\DoReflection\DoReflection\bin\Debug\netcoreapp2.1\Cars.dll";
            Assembly asm = Assembly.LoadFrom(asmName);

            Type ladaType = asm.GetType("CarsPro.LadaSedan", false, true);

            Type wheelsValidationAttribute = asm.GetType("CarsPro.WheelsCountAttribute", false, true);

            var ctorCars = ladaType.GetConstructor(new Type[] {typeof(string), typeof(string), typeof(System.Int32), typeof(string)});

            var c = ctorCars.Invoke(new object[] {"r", "r", 2, "r" });

            ValidationCar(c, wheelsValidationAttribute);

            var methods = from m in ladaType.GetMethods() select m;

            foreach (var item in methods)
            {
                Console.WriteLine(item);
            }

            //var method = ladaType.GetMethod("ViewInfo");

            //method.Invoke(c, new object[] { });


            var privateMethod = ladaType.GetMethod("PrivateMove", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

            //privateMethod.Invoke(c, new object[] { });


            Console.WriteLine(c.GetType());

            //var ac = Activator.CreateInstance();

            Console.ReadKey();

            }

        private static void ValidationCar(object c, Type attrType)
        {
            Type t = c.GetType();

            int currentWheelsCount = (int)t.GetProperty("WheelsCount").GetValue(c);

            var attrs = from atr in t.GetCustomAttributes(attrType, false) select atr;

            foreach (var item in attrs)
            {
                int wc = (int)attrType.GetProperty("Count").GetValue(item);

                if (currentWheelsCount < wc)
                {
                    Console.WriteLine($"current car has {currentWheelsCount} wheels count, but needs {wc}");
                }
            }
        }

        static void DisplayTypesInAsm(Assembly asm)
        {
            Type[] types = asm.GetTypes();

            foreach (var item in types)
            {
                Console.WriteLine(item);
            }
        }

    }
}
