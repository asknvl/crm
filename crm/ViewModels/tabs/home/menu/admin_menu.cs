using crm.ViewModels.tabs.home.menu.items;
using crm.ViewModels.tabs.home.screens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            users.AddScreen(new screens.UserActions());
            users.ScreenCheckedEvent += ScreenCheckedEvent;                       
            AddItem(users);

            BaseMenuItem users1 = new Users();
            users1.AddScreen(new screens.UserList());
            users1.AddScreen(new screens.UserActions());
            users1.ScreenCheckedEvent += ScreenCheckedEvent;
            AddItem(users1);
        }

        private void ScreenCheckedEvent(BaseScreen arg1, bool arg2)
        {
            Debug.WriteLine(arg1 + "=" + arg2);
            foreach (var item in Items)
                foreach (var screen in item.Screens)
                    if (!screen.Equals(arg1))
                        screen.Uncheck();
        }

        
    }
}
