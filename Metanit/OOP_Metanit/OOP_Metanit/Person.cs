using System;


namespace OOP_Metanit
{
    class Person
    {
        string name;        

        public string Name
        { set { name = value + "_change_"; }
            get { return name; }
        }

        public int Age { get; set; }


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //public Person() : this("Vasyan", 22)
        //{

        //}


        public void GetInfo()
        {
            Console.WriteLine($"{Name} __ {Age} ");
        }

        public void GetInfo(string s)
        {
            Console.WriteLine($"{Name} __ {Age} ");

        }

    }

    class Employee : Person
    {
        public string CompanyName { get; set; }

        public Employee(): base("Vasian", 12)
        {

        }

        public void GetInfo()

        {
            Console.WriteLine("Employee");

        }
    }
}


