using crm.Models.user;
using crm.ViewModels.tabs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace crm.ViewModels
{   
    public class mainVM : ViewModelBase
    {

        #region vars
        loginVM loginTab;
        tokenVM tokenTab;
        #endregion

        #region properties
        BaseUser user;
        public BaseUser User
        {
            get => user;
            set => this.RaiseAndSetIfChanged(ref user, value);  
        }

        public ObservableCollection<Tab> TabsList { get; set; } = new ObservableCollection<Tab>() { 
            //new loginVM(),            
            //new tokenVM()
        };

        object? content;
        public object? Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }
        #endregion

        public mainVM()
        {
            loginTab = new loginVM();
            tokenTab = new tokenVM();

            loginTab.onEnterAction += () => { 
            };
            loginTab.onCreateUserAction += () =>
            {
                TabsList.Add(tokenTab);
                Content = tokenTab;
            };

            TabsList.Add(loginTab);
            Content = loginTab;
        }

        #region helpers
        void addTab(Tab tab)
        {
            
        }
        #endregion

    }
}
