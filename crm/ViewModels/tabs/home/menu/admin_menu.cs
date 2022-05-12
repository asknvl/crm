using Avalonia.Media;
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

            SimpleMenuItem dashboard = new items.Dashboard();
            dashboard.AddScreen(new screens.Dashboard());            
            dashboard.ScreenCheckedEvent += ScreenCheckedEvent;
            AddItem(dashboard);

            ComplexMenuItem users = new Users();
            users.IsItemExpandedEvent += ItemExpandedEvent;
            users.AddScreen(new screens.UserList());
            users.AddScreen(new screens.UserActions());
            users.ScreenCheckedEvent += ScreenCheckedEvent;                       
            AddItem(users);

            IsMenuExpanded = true;
            MenuExpandedEvent += Menu_ExpandedEvent;
        }

        private void Menu_ExpandedEvent(bool expanded)
        {
            if (expanded)
            {
                foreach (var item in Items)
                {
                    if (item is ComplexMenuItem)
                    {
                        ComplexMenuItem citem = (ComplexMenuItem)item;
                        bool chkd = citem.Screens.Any(o => o.IsChecked);
                        if (chkd)
                            citem.SetExpanderSelected(false);
                    }
                }
                var itemToExpand = Items.FirstOrDefault(o => o is ComplexMenuItem && o.Screens.Any(s => s.IsChecked));
                if (itemToExpand != null)
                    ((ComplexMenuItem)itemToExpand).Expand();

                return;
            }
            foreach (var item in Items)
            {
                if (item is ComplexMenuItem)
                {
                    ComplexMenuItem citem = (ComplexMenuItem)item;
                    citem.Collapse();
                    bool chkd = citem.Screens.Any(o => o.IsChecked);
                    if (chkd)
                        citem.SetExpanderSelected(true);
                }
            }
        }

        private void ItemExpandedEvent()
        {
            IsMenuExpanded = true;                       
        }

        private void ScreenCheckedEvent(BaseScreen s, bool v)
        {

            foreach (var item in Items)
            {
                if (item is ComplexMenuItem)
                {
                    ((ComplexMenuItem)item).SetExpanderSelected(false);
                }
                    
                foreach (var screen in item.Screens)
                    if (!screen.Equals(s))
                        screen.Uncheck();
            }
        }        
    }
}
