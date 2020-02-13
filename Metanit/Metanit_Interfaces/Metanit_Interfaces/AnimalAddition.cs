using System;
using System.Collections.Generic;
using System.Text;

namespace Metanit_Interfaces
{
    partial class Animal
    {
        public string Type { get; set; }

        public void GetTypeAnimal()
        {
            Console.WriteLine("sdfsdf" + Type);
        }
    }
}
