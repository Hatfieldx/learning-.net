using System;

namespace Observer
{
    class Person 
    {
        protected NewsReceiver news;

        public virtual NewsReceiver News
        {
            get;

            set;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
