using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.validators
{
    public class LoginValidator<T> : IValidator<T>
    {
        string domen = "@protonmail.com";
        public string Message => "Введен неправильный адрес электронной почты";
        public bool IsValid(T value)
        {
            if (value == null)
                return false;
            string login = value.ToString();
            return login.EndsWith(domen) && login.Length > domen.Length;            
        }
    }
}
