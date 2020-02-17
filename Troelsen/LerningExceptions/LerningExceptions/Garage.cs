using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LerningExceptions
{
    class Garage:IEnumerable
    {
        Car[] cars = new Car[0];

        public int Count { get => cars.Length; }

        public Car this[int index]
        {
            get 
            {
                if (index > 0 && index < cars.Length)
                    return cars[index];
                else throw new IndexOutOfRangeException($"значение индекса {index}. В гараже всего {cars.Length} машин");
            }           
            
            set 
            {
                if (index > 0 && index < cars.Length)
                    cars[index] = value;
                else throw new IndexOutOfRangeException($"значение индекса {index}. В гараже всего {cars.Length} машин");
            }
        }
        
        public void Add(Car car)
        {
            
            Car[] temp = new Car[cars.Length];

            cars.CopyTo(temp, 0);

            cars = new Car[temp.Length + 1];

            for (int i = 0; i < temp.Length; i++)
            {
                cars[i] = temp[i];
            }

            cars[cars.Length - 1] = car;
        }

        public void Remove(Car car)
        {
            if (cars.Length == 0)
                return;
            
            Car[] temp = new Car[cars.Length-1];

            int j = 0;

            for (int i = 0; i < cars.Length-1; i++)
            {
                if (cars[i] != car)
                {
                    temp[j] = cars[i];
                    j++;
                }
                else continue;
            }

            cars = new Car[temp.Length];

            temp.CopyTo(cars, 0);
        }

        public void Clear()
        {
            
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                yield return cars[i];
            }
            
            //return new GarageEnumerator(cars);
        }

        void GetInfo<T>(int index) => Console.WriteLine("Info");
    }

    static class GarageExt
    {
        public static void ExtMethod(this Garage garage)
        {
            Console.WriteLine("Сейчас в гараже {0} машин", garage.Count);
        }

    }


    class GarageEnumerator : IEnumerator
    {
        Car[] cars;
        int pos = -1;

        public object Current
        {
            get 
            { 
                if (cars == null)
                    throw new NullReferenceException("Коллекция не может быть null");

                return cars[pos]; 
            }
        }    

        public bool MoveNext()
        {
            if (++pos < cars.Length)
                return true;
            else
                Reset();

            return false;
        }

        public void Reset()
        {
            pos = -1;
        }

        public GarageEnumerator(Car[] garage)
        {
            cars = garage;
        }
    }
}


