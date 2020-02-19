using System;

namespace Observer
{
    class NewsReceiver : IObserver<INews>
    {
        public event EventHandler newsHandler;
        public event EventHandler newsErrorHandler;

        public IDisposable Unsubscriber { get; set; }

        void InvokeNewsHandler(EventHandler e, INews value)
        {
             e?.Invoke(this, new ObserverEventArgs(value.Newspapier) {News = value});
        }

        void InvokeErrorNewsHandler(EventHandler e, string msg)
        {
            e?.Invoke(this, new ObserverEventArgs(msg));
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            InvokeErrorNewsHandler(newsErrorHandler, error.Message);
        }

        public void OnNext(INews value)
        {
            InvokeNewsHandler(newsHandler, value);
        }

        public virtual void Unsubscribe()
        {
            if (Unsubscriber != null)
            {
                Unsubscriber.Dispose();
            }
        }
    }
}
