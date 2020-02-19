using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Observer
{
    abstract class Notificator<T> : IObservable<T>
    {
        List<IObserver<T>> observers;
        
        public virtual IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber<T>(observers, observer);
        }

        public virtual void DoNotify(T ob)
        {
            foreach (IObserver<T> observer in observers)
            {
                if (ob == null)
                    observer.OnError(new NullReferenceException("НИЧЕГО НЕТ!!!"));
                else
                    observer.OnNext(ob);
            }
        }

        public Notificator()
        {
            observers = new List<IObserver<T>>();
        }

        private class Unsubscriber<T> : IDisposable
        {
            List<IObserver<T>> observers;

            IObserver<T> observer;

            public void Dispose()
            {
                if (observer != null && observers.Contains(observer))
                {
                    observers.Remove(observer);
                } 
            }

            public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }
        }
    }
}
