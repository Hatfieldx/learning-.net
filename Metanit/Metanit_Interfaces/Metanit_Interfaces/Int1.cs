using System;
using System.Collections.Generic;
using System.Text;
using Minio;

namespace Metanit_Interfaces
{
    interface IMovable
    {
       int Speed{set;get;}

       void Move();

        event Action myEvent; 
    }

    class Int1 : IMovable
    {
        public int Speed { get; set; }

        public event Action myEvent;

        public void Move()
        {
            Console.WriteLine($"Move speed{Speed}");
        }
    }

    class Person : IIClonable<Person>, IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Company Work { get; set; }

        public Person Clone()
        {

            Person newPerson = (Person)this.MemberwiseClone();

            newPerson.Work = this.Work.Clone();

            return newPerson;
            
            //return new Person() { Age = this.Age, Name = this.Name, Work = this.Work.Clone()};
        }

        public int CompareTo(Person other)
        {
            int res = 0;

            if (other.Age > this.Age)
                res = -1;
            else if (other.Age == this.Age)
                res = 0;
            else
                res = 1;
         
            return res;
        }
    }

    public class Company : IIClonable<Company>
    {
        public string Name { get; set; }
        public Company Clone()
        {
            Company newComoany = (Company)this.MemberwiseClone();

            return (Company)this.MemberwiseClone();

            //return new Company() { Name = this.Name};
        }
    }

    interface IIClonable<T>
    {
        T Clone();
    }

    static class PersonExt
    {
        public static void Printer<T>(this IIClonable<T> p)
        {
            Console.WriteLine(p.Clone());
        }

    }

  

}
