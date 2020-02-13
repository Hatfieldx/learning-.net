using System;
using System.Collections.Generic;
using System.Text;

namespace Metanit_Delegate
{
    delegate void AccountHandler<T, U>(T p1, U p2, object source, AccauntEventArgs args);

    struct AccauntEventArgs
    {
        public string Message { get; set; }

        public int Val { get; set; }

        public AccauntEventArgs(string mes, int val)
        {
            Message = mes;

            Val = val;
        }
    }

    class Account<T, U>
    {
        event AccountHandler<T,U> someEvent;

        public event AccountHandler<T,U> SomeEvent
        {
            add { someEvent += value; }

            remove { someEvent -= value; }
        } 

        //public void RegAccHandler(AccountHandler<U> acc)
        //{
        //    accountHandler += acc;
        //}

        //public void DeregAccHandler(AccountHandler<U> acc)
        //{
        //    accountHandler -= acc;
        //}

        public decimal Sum { get; private set; }

        public void Add(decimal x, T p1, U p2)
        {            
            Sum += x;


            someEvent?.Invoke(p1, p2, this, new AccauntEventArgs("Hello", 500));

        }
        public void Rem(decimal x, T p1, U p2)
        {
            if (Sum >= x)
            {
                Sum -= x;

                someEvent?.Invoke(p1, p2, this, new AccauntEventArgs("Hello", 500));
            }    
        }
    }


    delegate T FigureDelegateCova<out T>();

    delegate Figure Figa();

    delegate void Rectangle(Rect par);

    delegate void ContrTest(Figure par);

    class Figure
    {
        public string Name { get; set; }

        public int SideA { get; set; }

        public int SideB { get; set; }

        public Figure(int a, int b)
        {
            SideA = a;
            SideB = b;
        }

        public static implicit operator Rectangle(Figure v)
        {
            throw new NotImplementedException();
        }
    }

    class Rect:Figure
    {

        public string Comment { get; set; }
        public Rect(int a, int b) : base(a,b)
        {

        }
    }

}
