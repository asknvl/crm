using crm.ViewModels.tabs.home.screens;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.menu
{
    public abstract class BaseMenu : ViewModelBase
    {
        #region properties
        public ObservableCollection<BaseMenuItem> Items { get; set; } = new ObservableCollection<BaseMenuItem>();

        bool isMenuExpanded;
        public bool IsMenuExpanded
        {
            get => isMenuExpanded;
            set
            {
                this.RaiseAndSetIfChanged(ref isMenuExpanded, value);
                MenuExpandedEvent?.Invoke(value);
            }
        }
        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> collapseCmd { get; }
        #endregion

        #region public
        public void AddItem(BaseMenuItem item)
        {
            Items.Add(item);
        }
        #endregion

        #region callbacks
        public event Action<bool>? MenuExpandedEvent;
        #endregion

    }
}
