using crm.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.user
{
    public abstract class BaseUser : ViewModelBase
    {
        #region properties
        string email;
        public string Email 
        {
            get => email;
            set => this.RaiseAndSetIfChanged(ref email, value);
        }
        string password;
        public string Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);
        }
        string fullname;
        public string FullName
        {
            get => fullname;
            set => this.RaiseAndSetIfChanged(ref fullname, value);
        }
        string birthdate;
        public string BirthDate
        {
            get => birthdate;
            set => this.RaiseAndSetIfChanged(ref birthdate, value);
        }
        string phonenumber;
        public string PhoneNumber
        {
            get => phonenumber;
            set => this.RaiseAndSetIfChanged(ref phonenumber, value);
        }
        string telegram;
        public string Telegram
        {
            get => telegram;
            set => this.RaiseAndSetIfChanged(ref telegram, value);
        }
        string wallet;
        public string Wallet
        {
            get => wallet;
            set => this.RaiseAndSetIfChanged(ref wallet, value);
        }
        string[] devices;
        public string[] Devices
        {
            get => devices;
            set => this.RaiseAndSetIfChanged(ref devices, value);
        }
        #endregion
    }
}
