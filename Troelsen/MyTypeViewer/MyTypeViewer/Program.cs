using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName = "";
            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                // Предложить ввести имя типа
                Console.Write("or enter Q to quit: ");
                // или Q для завершения.
                // Получить имя типа.
                typeName = Console.ReadLine();
                // Пользователь желает завершить программу?
                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                // Попробовать отобразить информацию о типе.
                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can’t find type"); // He удается найти тип.
                }
            } while (true);

        }

        static void ListMethods(Type t)
        {
            MethodInfo[] mInfo = t.GetMethods();

            //(from m in t.GetMethods() where m.IsStatic select m).AsParallel().ForAll(m => Console.WriteLine($"LINQ Static methods is {m.Name}"));

          // t.GetMethods().SelectMany(m => m.GetParameters(), (m, k) => new { Method = m, Params = m.GetParameters() }).AsParallel().ForAll(x => Console.WriteLine($"metod {x.Method} has params {x.Params}"));

            foreach (MethodInfo item in mInfo)
            {
                ParameterInfo parInfo = item.ReturnParameter;

                ParameterInfo[] inpPar = item.GetParameters();

                Console.WriteLine(item);
            }

        }

        static void ListFields(Type t)
        {
            FieldInfo[] mInfo = t.GetFields();

            MemberInfo[] memInfo = t.GetFields();

            (from m in t.GetFields() select m).AsParallel().ForAll(m => Console.WriteLine($"LINQ fields is {m.Name}"));
        }

        static void ListProps(Type t)
        {
            PropertyInfo[] mInfo = t.GetProperties();

            MemberInfo[] memInfo = t.GetProperties();

            (from m in t.GetProperties() select m).AsParallel().ForAll(m => Console.WriteLine($"LINQ properties is {m.Name}"));
        }

        static void ListInterfaces(Type t)
        {
            Type[] mInfo = t.GetInterfaces();

            MemberInfo[] memInfo = t.GetProperties();

            (from m in t.GetInterfaces() select m).AsParallel().ForAll(m => Console.WriteLine($"LINQ interfaces is {m.Name}"));
        }

        // Просто ради полноты картины,
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            // Базовый класс
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            // Абстрактный?
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            // Запечатанный?
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            // Обобщенный?
            Console.WriteLine("Is type a class type? {0}", t.IsClass); // Класс?
            Console.WriteLine();
        }
    }
}
