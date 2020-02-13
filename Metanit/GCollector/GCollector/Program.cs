using System;

namespace GCollector
{

    class Car
    {
        public object[] mod;

        public string Name { get; set; }

        public string Vendor { get; set; }

        public Car(string name, string vendor)
        {
            Name = name;
            Vendor = vendor;

            mod = new object[50000];

            for (int i = 0; i < 50000; i++)
            {
                mod[i] = i;
            }

            Console.WriteLine("BIG DATA CREATED!!!!!!!!");
        }

        public void ViewInfo()
        {

            Console.WriteLine($"{Name} - {Vendor}");
        }

    }
    struct Person
    {

      public  int height, age;

        public int d;

        public int Height {
            get { return height; }
            set => height = value;
        }

        public int Age
        {
            get { return age; }
            set => age = value;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{Height}, {Age}");
        }

        //public Person(int height, int age)
        //{
        //    Age = age;

        //    Height = height;
        //}    
    }
    class Program
    {
        static void Main(string[] args)
        {

            //FinUser();

            // Console.WriteLine("Leave metho which used User");

            //GC.Collect(0, GCCollectionMode.Forced);

            //Console.WriteLine("after gc");

            User usr = new User("An", 22);

            Console.WriteLine("PAUSED");
            usr.ShowCar();

            Console.WriteLine(new string('=', 20));
            unsafe
            {
                const int size = 7;

                int* fact = stackalloc int[size];

                int* p = fact;

                *p = 1;

                p++;

                *p = 2;

                p++;

                *p = 3;

                p++;

                *p = 4;

                p++;

                *p = 5;

                p++;

                *p = 6;

                p++;

                *p = 7;

                p = (p-size+1);

                for (int i = 1; i <= size; ++i)
                {
                    Console.WriteLine(p[i-1]);
                }

                Console.WriteLine(new string('=', 20));

                int *x;
                int** z;


                //Console.WriteLine((ulong)z);
                int y = 10;

                x = &y;
                z = &x;

                *x += 50;

                Console.WriteLine(y);

                Person person;

                person.height = 32;

                person.age = 12;

                Person* uRef = &person;

                Console.WriteLine(uRef->height);

                Console.WriteLine(*x);
                Console.WriteLine(**z);

                
            }
            

            Console.ReadKey();
        }

        private static void FinUser()
        {
            using (User u = new User("Andew", 18))
            {
                u.Age = 23;

                Console.WriteLine($"{u.Name}, {u.Age}");
            }
        }
    }

    class User: IDisposable
    {
        Lazy<Car> mashinka = new Lazy<Car>(()=>new Car("Lada", "Rus"));

        private bool disposed = false;

        public string Name { get; set; }

        public int Age { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, {Age}");
        }

        public void ShowCar()
        {
            mashinka.Value.ViewInfo();
        }

        public User(string name, int age)
        {
            Age = age;

            Name = name;
        }

        protected virtual void Dispose(bool disposible)
        {
            if (disposed)
                return;

            if (disposible)
            {
                
            }

            //Console.WriteLine($"{Name},{Age} is dispossed");
           // Console.Beep(1000, 2000);

            disposed = true;

            
        }

        ~User()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

    }


}
