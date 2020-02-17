using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ModelValidation
{
    class UserModelAttribute: ValidationAttribute 
    {
        public override bool IsValid(object value)
        {
            User user = value as User;

            string pattern = @"^[a-zа-я]+$";

            bool res = true;            
            
            if (user == null )
            {
                ErrorMessage = "Передан пустой или несовместимый экземпляр для валидации";
                
                return false;
            }

            if (user.Age > 100 || user.Age < 1)
            {
                ErrorMessage += "Возраст должен быть в диапазоне 1-100\n";

                res = false;
            }

            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);

            if (rg.Matches(user.Name).Count == 0)
            {
                ErrorMessage += "Имя не должно содержать посторонние символы!\n";

                res = false;
            }
            
            return res;
        }
    }
}
