using System;
using System.Collections.Generic;
using System.Text;

namespace ModelValidation
{
    interface IUser
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Age { get; set; }

        void ShowInfo();

    }
}
