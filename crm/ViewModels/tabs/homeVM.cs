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

        public homeVM(ViewModelBase parent) : base(parent)
        {
            Title = "Домой";
            Screen = new userScreenVM();
        }
    }
}
