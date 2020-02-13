using System;
using System.Collections.Generic;
using System.Text;

namespace CarsPro
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class WheelsCountAttribute : System.Attribute 
    {
        public int Count { get; set; }

        public WheelsCountAttribute(int count)
        {
            this.Count = count;
        }
    }
}
