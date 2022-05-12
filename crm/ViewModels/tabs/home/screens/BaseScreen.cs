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

        #region properties
        bool NeedInvoke { get; set; } = true;

        bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                if (NeedInvoke && !value)
                    return;
                   
                this.RaiseAndSetIfChanged(ref isChecked, value);
                if (NeedInvoke)
                    ScreenCheckedEvent?.Invoke(this, value);
            }
        }

        public abstract string Title { get; }
        #endregion

        #region public
        public void Uncheck()
        {
            NeedInvoke = false;
            IsChecked = false;
            NeedInvoke = true;
        }
        #endregion

        #region callbacks
        public event Action<BaseScreen, bool>? ScreenCheckedEvent;
        #endregion

    }
}
