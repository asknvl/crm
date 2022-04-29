using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public abstract class Tab : ViewModelBase
    {

        #region properties
        protected ViewModelBase Parent { get; }

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
        protected bool needValidate { get; set; }
        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> closeCmd { get; }
        #endregion

        public Tab(ViewModelBase parent)
        {
            Parent = parent;

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

        #region abstract        
        abstract public void Clear();        
        #endregion
    }
}
