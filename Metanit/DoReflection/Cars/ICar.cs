using System;
using System.Collections.Generic;
using System.Text;

namespace CarsPro
{
    interface ICar
    {
        int WheelsCount { get; set; }

        string Color { get; set; }

        string ModelName { get; set; }

        string Factory { get; set; }

        void Move();

        void ViewInfo();
    }
}
