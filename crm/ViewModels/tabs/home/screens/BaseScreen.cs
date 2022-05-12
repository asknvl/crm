using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.screens
{
    public abstract class BaseScreen : ViewModelBase
    {

        bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {                
                this.RaiseAndSetIfChanged(ref isChecked, value);
                ScreenCheckedEvent?.Invoke(this, value);
            }
        }

        public abstract string Title { get; }

        public event Action<BaseScreen, bool>? ScreenCheckedEvent;

    }
}
