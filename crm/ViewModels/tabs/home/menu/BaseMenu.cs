using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.menu
{
    public abstract class BaseMenu : ViewModelBase
    {
        public ObservableCollection<BaseMenuItem> Items { get; set; } = new ObservableCollection<BaseMenuItem>();
        public event Action<screens.BaseScreen> ScreenChecked;

        public void AddItem(BaseMenuItem item)
        {
            Items.Add(item);
        }
        
    }
}
