using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.validators
{
    public class LoginValidator<T> : IValidator<T>
    {
        public bool IsValid(T value)
        {
            if (value == null)
                return false;
            string login = value.ToString();
            return login.EndsWith("@protonmail.com");            
        }
    }
}
