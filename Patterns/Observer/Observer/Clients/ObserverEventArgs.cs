using System;

namespace Observer
{
    class ObserverEventArgs : EventArgs
    {
        public string Message { get; set; }

        public INews News { get; set; }

        public ObserverEventArgs(string msg)
        {
            Message = msg;
        }
    }
}
