using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.validators
{
    public class PasswordValidator<T> : IValidator<T>
    {
        public string Message => "Пароль должен состоять не менее, чем из 12 символов и содрежать в себе буквы, числа и знаки";

        public bool IsValid(T value)
        {
            if (value == null)
                return false;

            string password = value.ToString();
            if (password.Length < 12)
                return false;

            bool result =
            password.Any(c => char.IsLetter(c)) &&
            password.Any(c => char.IsDigit(c)) &&
            password.Any(c => char.IsSymbol(c));

            return result;
        }
    }
}
