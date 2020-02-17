
using System;

namespace LerningExceptions
{
    class CarEventArguments:EventArgs
    {
        public string Message { get; set; }
        
        public CarEventArguments(string message)
        {
            Message = message;
        }
    }
}
