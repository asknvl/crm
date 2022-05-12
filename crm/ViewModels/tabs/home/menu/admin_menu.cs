using crm.ViewModels.tabs.home.menu.items;
using crm.ViewModels.tabs.home.screens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.menu
{
    public class admin_menu : BaseMenu
    {
        public admin_menu()
        {

            BaseMenuItem dashboard = new items.Dashboard();
            dashboard.AddScreen(new screens.Dashboard());            
            dashboard.ScreenCheckedEvent += ScreenCheckedEvent;
            AddItem(dashboard);

            BaseMenuItem users = new Users();
            users.AddScreen(new screens.UserList());
            users.ScreenCheckedEvent += ScreenCheckedEvent;                       
            AddItem(users);            
        }

        private void ScreenCheckedEvent(BaseScreen arg1, bool arg2)
        {
            
        }

        
    }
}
