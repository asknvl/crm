using crm.Models.user;
using crm.ViewModels.tabs.homeTabScreens;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class homeVM : Tab
    {

        object screen;
        public object Screen
        {
            get => screen;
            set => this.RaiseAndSetIfChanged(ref screen, value);
        }

        BaseUser user;
        BaseUser User
        {
            get => user;            
            set => this.RaiseAndSetIfChanged(ref user, value);                         
            
        }

        string initialLetter;
        public string InitialLetter
        {
            get => initialLetter;
            set => this.RaiseAndSetIfChanged(ref initialLetter, value);
        }



        public homeVM(ViewModelBase parent) : base(parent)
        {
                
            User = new User();
            User.FullName = "Алексей Сергеевич Коновалов";
            User.Email = "mymail@protonmail.com";

            Title = "Домой";
            Screen = new userScreenVM();

        }
    }
}
