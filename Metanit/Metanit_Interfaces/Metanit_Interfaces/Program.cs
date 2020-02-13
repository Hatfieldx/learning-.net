using System;

namespace Metanit_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovable int1 = new Int1();

            int1.Speed = 500;

            int1.Move();

            Person p1 = new Person()
            {
                Name = "Ivan",
                Age = 15,
                Work = new Company() {Name = "Apple" }
            };

            Person p2 = p1.Clone();

            //Console.WriteLine($"Person 1 Name  = {p1.Name} reff = {p1.GetHashCode()}");
            //Console.WriteLine($"Person 1 CompanyName  = {p1.Work.Name} reff = {p1.Work.GetHashCode()}");
            //Console.WriteLine($"Person 2 Name  = {p2.Name} reff = {p2.GetHashCode()}");
            //Console.WriteLine($"Person 2 CompanyName  = {p2.Work.Name} reff = {p2.Work.GetHashCode()}");

            Person p3 = new Person()
            {
                Name = "Ivan",
                Age = 1,
                Work = new Company() { Name = "Apple" }
            };
            
            Person p4 = new Person
            {
                Name = "Ivan",
                Age = 45,
                Work = new Company() { Name = "Apple" }
            };

            Person p5 = new Person()
            {
                Name = "Ivan",
                Age = 30,
                Work = new Company() { Name = "Apple" }
            };

            Person[] personList = {p1, p2, p3, p4, p5};

            Array.Sort<Person>(personList);

            foreach (var item in personList)
            {
                Console.WriteLine(item.Age);
            }

            IIClonable<Person> ext = p1;

            ext.Printer<Person>();

            Animal animal = new Animal {Name = "Loki", Type = "Dog" };

            animal.GenName();

            animal.GetTypeAnimal();

            var user = new {name = "Ivan", Age = 25 };

            int age = 15;

            var pers = new { p5.Name, age };

            Console.WriteLine($"{pers.Name}  {pers.age}");

            Console.ReadKey();
        }

        public void Solve (int x , int y)
        {
            int z = 10;

            int k = 15;

            Sum(ref z,k);

            void Sum(ref int h , int j)
            {
                h += j + z;
            }

            int n = 15;



        }
    }
}
