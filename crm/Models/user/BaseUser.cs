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
        string id;
        public string Id {
            get => id;
            set => this.RaiseAndSetIfChanged(ref id, value);    
        }
        string token;
        public string Token { get; set; }

        string litera;
        public string Litera
        {
            get => litera;
            set => this.RaiseAndSetIfChanged(ref litera, value);    
        }

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

        string lastname;
        public string LastName
        {
            get => lastname;
            set => this.RaiseAndSetIfChanged(ref lastname, value);
        }

        string firstname;
        public string FirstName
        {
            get => firstname;
            set => this.RaiseAndSetIfChanged(ref firstname, value);
        }

        string middlename;
        public string MiddleName
        {
            get => middlename;
            set => this.RaiseAndSetIfChanged(ref middlename, value);
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

        SocialNetwork[] socialnetworks;
        public SocialNetwork[] SocialNetworks
        {
            get => socialnetworks;
            set => this.RaiseAndSetIfChanged(ref socialnetworks, value);
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

        string lastlogindate;
        public string LastLoginDate
        {
            get => lastlogindate;
            set => this.RaiseAndSetIfChanged(ref lastlogindate, value);
        }

        string lasteventdate;
        public string LastEventDate
        {
            get => lasteventdate;
            set => this.RaiseAndSetIfChanged(ref lasteventdate, value);
        }

        Device[] devices;
        public Device[] Devices
        {
            get => devices;
            set => this.RaiseAndSetIfChanged(ref devices, value);
        }

        Role[] roles;
        public Role[] Roles
        {
            get => roles;
            set => this.RaiseAndSetIfChanged(ref roles, value);
        }
        #endregion
    }
}
