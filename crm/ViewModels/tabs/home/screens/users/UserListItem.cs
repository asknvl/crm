using crm.Models.user;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.screens.users
{
    public class UserListItem : BaseUser
    {
        bool status;
        public bool Status
        {
            get => status;
            set => this.RaiseAndSetIfChanged(ref status, value);
        }

        //public string ShortWallet => $"{Wallet.Substring(0, 15)}...";
        public string ShortWallet => $"{Wallet}";
    }
}
