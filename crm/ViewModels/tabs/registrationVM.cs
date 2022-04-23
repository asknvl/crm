using Avalonia.Data;
using crm.Models.autocompletions;
using crm.Models.validators;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class registrationVM : Tab
    {
        #region vars
        bool isEmail;
        IValidator<string> email_vl = new LoginValidator<string>();
        IAutoComplete email_av = new EmailAutoComplete();
        #endregion
        #region properties
        string email;
        public string Email
        {
            get => email;
            set
            {
                value = email_av.AutoComplete(value);
                isEmail = email_vl.IsValid(value);

                if (!isEmail)
                    throw new DataValidationException("Введен некорректный e-mail");                
                this.RaiseAndSetIfChanged(ref email, value);
            }
        }

        string password1;
        public string Password1
        {
            get => password1;
            set
            {
                this.RaiseAndSetIfChanged(ref password1, value);
            }
        }
        #endregion



        public registrationVM()
        {
            Title = "Регистрация";

            IsInputValid = CheckValidity(new bool[] { 
                isEmail 
            });

        }
    }
}
