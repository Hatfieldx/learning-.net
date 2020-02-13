using System;
using System.Collections.Generic;
using System.Text;

namespace Metanit_Delegate
{
    struct PingPongArg
    {
        public int Count { get; set; }

        public Ping pingPlayer { get; set; }

        public Pong pongPlayer { get; set; }
    }
    class Ping
    {
        event Action<object, PingPongArg, string> pingHandler;

        public event Action<object, PingPongArg, string> PingHandler
        {
            add { pingHandler += value; }

            remove { pingHandler -= value; }
        }

        const string message = "ping";
                     
        public void PingMethod(PingPongArg arg)
        {
            pingHandler?.Invoke(this, arg, message);
        }
    }

    class Pong
    {
        const string message = "pong";

        event Action<object, PingPongArg, string> pongHandler;

        public event Action<object, PingPongArg, string> PongHandler
        {
            add { pongHandler += value; }

            remove { pongHandler -= value; }
        }

        public void PongMethod(PingPongArg arg)
        {
            pongHandler?.Invoke(this, arg, message);
        }

    }
}
