using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ModelValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "Моеим_явася",
                Status = "TestStatus",
                Age = 250
            };

            var res = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, new ValidationContext(user), res, true))
            {
                (from ex in res select ex).AsParallel().ForAll(x => Console.WriteLine(x.ErrorMessage));
            }

            Console.ReadKey();
        }
    }
}
