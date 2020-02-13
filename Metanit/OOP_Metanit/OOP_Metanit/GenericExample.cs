using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Metanit
{
    class GenericExample
    {
    }

    class Instantiator<T>
    {
        public T instance;
        public Instantiator()
        {
           // instance = new T();
        }
    }

    class Operations<T>
    {
        private T[] mas = { };

        public T this[int index]
        {
            get
            {
                if (index <= mas.Length-1 && index >= 0)
                {
                    return mas[index];
                }

                return default(T);
            }
            set
            {
                if (index <= mas.Length - 1 && index >= 0)
                {
                    mas[index] = value;
                }                
            }
        }

        public Operations()
        {
                
        }

        public void Add(T newItem)
        {
            T[] temp = new T[mas.Length];

            for (int i = 0; i < mas.Length; i++)
            {
                temp[i] = mas[i];
            }

            mas = new T[temp.Length + 1];

            for (int i = 0; i < temp.Length; i++)
            {
                mas[i] = temp[i];
            }

            mas[temp.Length] = newItem;
        }

        public void Del(T item)
        {
            T[] temp = new T[mas.Length -1];

            bool isFinded = false;

            int j = 0;

            for (int i = 0; i < mas.Length; i++)
            {                
                if (mas[i].Equals(item))
                {
                    isFinded = true;
                    continue;
                }

                if (i == mas.Length-1 && !isFinded)
                {
                    break;
                }

                temp[j] = mas[i];
                j++;
            }

            mas = new T[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                mas[i] = temp[i];
            }            
        }

        public int GetLenth()
        {
            return mas.Length;
        }

    }
}
