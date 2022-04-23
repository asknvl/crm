using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.validators
{
    public class FullNameValidator : IValidator<string>
    {
        public string Message => "Неправильный формат ФИО";

        public bool IsValid(string value)
        {
            string[] splt = value.Split(' ');
            if (splt.Length != 3)
                return false;

            return true;
        }
    }
}
