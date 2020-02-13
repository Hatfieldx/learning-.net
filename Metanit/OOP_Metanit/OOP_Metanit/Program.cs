using System;
using TestLibrary;

namespace OOP_Metanit
{
    namespace MyNamespace
    {

    }
    struct Animal
    {
        string name;
        int age;
               
        public string Name {
            get { return name; }
            set { name = value; } }           

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Animal(string parName, int parAge)
        {
            this.name = parName;

            this.age = parAge;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Name} __ {Age} ");

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
           // ClassOperation1();            

            string s = null;

            string d = s ?? "Alfred";

            Console.WriteLine(d);

            Team redTeam = new Team();

            for (int i = 0; i <= 15; i++)
            {
                Console.WriteLine(redTeam[i] ?? "SOSI BIBU");
            }

            Dictionary dict = new Dictionary();

            Console.WriteLine(dict["red"]);

            dict["red"] = "krasnyi";

            Console.WriteLine(dict["red"]);

            Employee emp = new Employee() { CompanyName = "Random name"};

            Console.WriteLine(emp.Name);


            /////////////////////

            Employee emp1 = new Employee() {Name = "Alex", Age = 35, CompanyName = "MS" };

            Person p1 = emp1;

            ChangePerson(p1);

            Console.WriteLine(p1.Age);

            Console.WriteLine(emp1.Age);

            Employee emp3 = (Employee)p1;

            emp1 = (Employee)p1;

            Console.WriteLine($"{emp1.Name} {emp1.Age}");

            emp1.Name = "Valera";

            Console.WriteLine($"{emp3.Name} {emp3.Age}");            

            Console.WriteLine(emp1.GetHashCode());
            Console.WriteLine(emp3.GetHashCode());
            Console.WriteLine(p1.GetHashCode());

            Clock clock = new Clock();
            int val = 34;
            clock.Hours = val % 24;
            val = clock.Hours;

            int number = 56;

            clock = number;

            int a = (int)clock;

            Console.WriteLine(clock.Hours);

            Console.WriteLine(a);


            Fahrenheit tf = new Fahrenheit() { Gradus = 40 };

            Celcius tc = new Celcius() { Gradus = 40 };

            Celcius c1 = tf; // 0.55 * 8 = 4.4 

            Fahrenheit f1 = tc; // 1.8 * 72 = 129.6

            Console.WriteLine(c1.Gradus);

            Console.WriteLine(f1.Gradus);

            Dollar doll = new Dollar() { Sum = 7 };

            Euro euro = new Euro() { Sum = 5 };

            doll = euro;

            euro = doll;

            Console.WriteLine($"{doll.Sum} _ {euro.Sum}");

            p1.GetInfo();

            emp3.GetInfo();

            Person p2 = emp3;

            p2.GetInfo();

            Triangle triangle = new Triangle("Triangle");

            triangle.Show();


            Operations<int> mas = new Operations<int>();           

            mas.Add(3);
            mas.Add(4);
            mas.Add(5);
            mas.Add(9);

            int aa = mas[2];

            mas.Del(5);

            aa = mas[8];

            mas[2] = 6;



            Console.ReadKey();
        }

        private static void ChangePerson(Person p1)
        {
            p1.Age += 10; 
        }

        private static void ClassOperation1()
        {
            Console.WriteLine(Math.PI);

            Person nik = new Person("Nik", 44);

            nik.GetInfo();

            nik.Name = "Oleg";

            nik.GetInfo();

            Person olek = new Person("", 0) { Name = "Vitalya", Age = 32 };

            olek.GetInfo();

            Person Vasyan = new Person("das", 12);

            Vasyan.GetInfo();

            Animal tiger = new Animal();

            tiger.GetInfo();

            Person test1 = new Person("test", 22);

            Console.WriteLine(test1.GetHashCode());

            ModifiPerson(ref test1);

            Console.WriteLine(test1.GetHashCode());

            Car bmw = new Car("X5", "BMW", 4);

            Console.WriteLine(Car.Mov(1, 2, 3, 4, 5));

            Car.EngineCount = 4;

            State a = new State() { Population = 150, Area = 143.345M };
            State b = new State() { Population = 450, Area = 343.345M };

            State d = a + b;

            State.GetInfo(d);

            Console.WriteLine(a > b);

            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight);  // 100
        }

        private static void ModifiPerson(ref Person p)
        {
            Console.WriteLine(p.GetHashCode());

            p = new Person("Ann", 33);

            Console.WriteLine(p.GetHashCode());
        }
    }

}