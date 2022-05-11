using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.homeTabScreens
{
    public class userScreenVM : HomeTabScreen
    {

        //bool isexpanded;
        //public bool IsExpanded
        //{
        //    get => isexpanded;
        //    set => this.RaiseAndSetIfChanged(ref isexpanded, value);
        //}

        public userScreenVM()
        {
            IconPath = "/Assets/svgs/leftslidemenu/user.svg";
            Title = "Сотрудники";           
            SubScreens.Add(new userListVM());            
            //IsExpanded = true;
        }
    }
}
