using System;
using System.Collections.Generic;
using System.Text;

namespace Metanit_Interfaces
{
    partial class Animal
    {
        public string Name { get; set; }

        partial void Move(); 
        
        public void GenName()
        {
            Console.WriteLine(Name);
        }

    }
}
