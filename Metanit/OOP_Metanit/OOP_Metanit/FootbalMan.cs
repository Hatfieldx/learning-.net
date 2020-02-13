using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Metanit
{
    class FootbalMan
    {
        public string Name { get; set; }

        public int Number { get; set; }

    }

    class Team
    {
        FootbalMan[] footbalMan;

        public string this[int index]
        {
            get
            {
                return (index >= 0 && index <= footbalMan.Length-1) ? footbalMan[index].Name : null;
            }
            private set { footbalMan[index].Name = value; }
        }

        public Team()
        {
            int count = 11;

            footbalMan = new FootbalMan[count];

            for (int i = 0; i <= count-1; i++)
            {
                footbalMan[i] = new FootbalMan() {Name = string.Format($"FootbalMan_{i + 1}"), Number = i + 1};
            }
        }
    }
}
