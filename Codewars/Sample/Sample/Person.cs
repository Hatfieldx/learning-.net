using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    class Person
    {
        int age;
        
        public string Name { get; set; }

        public int Age
        {
            get 
            { 
                return age; 
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Возраст должен быть в диапазоне от 1 до 100");
                }
                age = value;
            }
        }

        public void PringInfo() => Console.WriteLine($"{Name} - {Age}");

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }
    }
}
