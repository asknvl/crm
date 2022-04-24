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
        bool isEmail,isPassword1, isPassword2, isFullName, isBirthDate, isPhoneNumber, isTelegram;
        IValidator<string> email_vl = new LoginValidator();
        IAutoComplete email_ac = new EmailAutoComplete();        
        IValidator<string> pswrd_vl = new PasswordValidator();
        IValidator<string> fn_vl = new FullNameValidator();
        IValidator<string> birth_vl = new BirthDateValidator();
        IAutoComplete birth_ac = new BirtDateAutoCompletion();
        IValidator<string> phone_vl = new PhoneNumberValidator();
        IValidator<string> tg_vl = new TelegramValidator();
        #endregion

        #region properties
        string email;
        public string Email
        {
            get => email;
            set
            {
                value = email_ac.AutoComplete(value);
                isEmail = email_vl.IsValid(value);
                if (!isEmail)
                    throw new DataValidationException("Введен некорректный e-mail");
                updateValidity();
                this.RaiseAndSetIfChanged(ref email, value);
            }
        }

        string password1;
        public string Password1
        {
            get => password1;
            set
            {
                isPassword1 = pswrd_vl.IsValid(value);
                if (!isPassword1)
                    throw new DataValidationException(pswrd_vl.Message);
                updateValidity();
                this.RaiseAndSetIfChanged(ref password1, value);
            }
        }

        string password2;
        public string Password2
        {
            get => password2;
            set
            {
                isPassword2 = pswrd_vl.IsValid(value);
                if (!isPassword2)
                    throw new DataValidationException(pswrd_vl.Message);
                isPassword2 = value.Equals(Password1);
                if (!isPassword2)
                    throw new DataValidationException("Введенные пароли не совпадают");
                updateValidity();
                this.RaiseAndSetIfChanged(ref password2, value);
            }
        }

        string fullname;
        public string FullName
        {
            get => fullname;
            set
            {
                isFullName = fn_vl.IsValid(value);
                if (!isFullName)
                    throw new DataValidationException(fn_vl.Message);
                updateValidity();
                this.RaiseAndSetIfChanged(ref fullname, value); 
            }
        }

        string birthdate;
        public string BirthDate
        {
            get => birthdate;
            set
            {                
                value = birth_ac.AutoComplete(value);
                isBirthDate = birth_vl.IsValid(value);
                if (!isBirthDate)
                    throw new DataValidationException(birth_vl.Message);
                updateValidity();
                this.RaiseAndSetIfChanged(ref birthdate, value);
            }
        }

        string phonenumber;
        public string PhoneNumber
        {
            get => phonenumber;
            set
            {
                isPhoneNumber = phone_vl.IsValid(value);
                if (!isPhoneNumber)
                    throw new DataValidationException(phone_vl.Message);
                updateValidity();
                this.RaiseAndSetIfChanged(ref phonenumber, value);
            }
        }

        string telegram;
        public string Telegram
        {
            get => telegram;
            set
            {
                isTelegram = tg_vl.IsValid(value);
                if (!isTelegram)
                    throw new DataValidationException(tg_vl.Message);
                updateValidity();
                this.RaiseAndSetIfChanged(ref telegram, value);
            }
        }
        #endregion

        public registrationVM()
        {
            Title = "Регистрация";

            IsInputValid = CheckValidity(new bool[] { 
                isEmail,
                isPassword1,
                isPassword2,
                isFullName,
                isBirthDate,
                isPhoneNumber,
                isTelegram,
                //isWallet,
                //isDevice
                true
            });

        }

        #region helpers
        void updateValidity()
        {
            IsInputValid = CheckValidity(new bool[] { 
                //isEmail,
                //isPassword1,
                //isPassword2,
                //isFullName,
                //isBirthDate,
                //isPhoneMumber,
                //isTelegram,
                //isWallet,
                //isDevice
                true
            });
        }
        #endregion
    }
}
