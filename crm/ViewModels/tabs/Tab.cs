using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public abstract class Tab : ViewModelBase
    {
        #region properties
        string title;
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        bool isInputValid;
        protected bool IsInputValid
        {
            get => isInputValid;
            set => this.RaiseAndSetIfChanged(ref isInputValid, value);
        }
        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> closeCmd { get; }
        #endregion

        public Tab()
        {
            closeCmd = ReactiveCommand.Create(() => {
                CloseTabEvent?.Invoke(this);
            });
        }

        #region protected
        protected bool CheckValidity(bool[] fields)
        {
            return !fields.Any(p => p == false);
        }
        #endregion

        #region public
        public event Action<Tab> CloseTabEvent;
        public void OnCloseTab()
        {
            CloseTabEvent?.Invoke(this);
        }
        #endregion
    }
}
