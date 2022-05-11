using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.homeTabScreens
{
    public abstract class HomeTabScreen : ViewModelBase
    {
        #region properties        
        public string IconPath { get; set; }

        string title;
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }
        public ObservableCollection<HomeTabScreen> SubScreens { get; } = new ObservableCollection<HomeTabScreen>();
        #endregion
    }
}
