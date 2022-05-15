using crm.Models.user;
using crm.ViewModels.tabs.home.screens.users;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.screens
{
    public class UserList : BaseScreen
    {
        #region properties
        public override string Title => "Список сотрудников";

        private string test;
        public string Test
        {
            get => test;
            set => this.RaiseAndSetIfChanged(ref test, value);
        }

        public ObservableCollection<UserListItem> Users { get; set; } = new ObservableCollection<UserListItem>() {
            new UserItemTest(),
            new UserItemTest()
        };
        #endregion

        public UserList()
        {
            Test = "Тест";
        }

        #region public
        #endregion

        #region override
        public override void OnActivate()
        {            
            base.OnActivate();
        }
        public override void OnDeactivate()
        {            
            base.OnDeactivate();
        }
        #endregion
    }
}
