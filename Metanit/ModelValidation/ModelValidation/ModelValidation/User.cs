using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ModelValidation
{
   // [UserModel]
    class User : IUser, IValidatableObject
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        //[Range(1, 100, ErrorMessage = "Возраст должен быть в диапазоне от 1 до 100")]
        public int Age { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Status} - {Age}");
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> response = new List<ValidationResult>();

            User user = validationContext.ObjectInstance as User;

            if (user == null)
            {
                response.Add(new ValidationResult("Передан пустой или несовместимый экземпляр для валидации"));

                return response;
            }

            if (user.Age > 100 || user.Age < 1)
            {
                response.Add(new ValidationResult("Возраст должен быть в диапазоне 1 - 100"));
            }

            Regex rg = new Regex(@"^[a-zа-я]+$", RegexOptions.IgnoreCase);

            if (rg.Matches(user.Name).Count == 0)
            {
                response.Add(new ValidationResult("Имя не должно содержать посторонние символы!"));
            }

            return response;
        }

        public User()
        {

        }
        public User(string name, string status, int age)
        {
            Name = name;
            Status = status;
            Age = age;
        }
    }
}
