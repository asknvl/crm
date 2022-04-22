using crm.Models.user;
using crm.ViewModels.tabs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ObservableCollection<Tab> TabsList { get; set; } = new ObservableCollection<Tab>()
        {
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

            #region loginTab
            loginTab = new loginVM();
            loginTab.CloseTabEvent += CloseTab;
            loginTab.onEnterAction += () => {
            };
            loginTab.onCreateUserAction += () =>
            {
                ShowTab(tokenTab);
            };
            #endregion

            #region tokenTab
            tokenTab = new tokenVM();
            tokenTab.CloseTabEvent += CloseTab;
            tokenTab.onTokenCheckResult += (result) => { 
                if (result)
                {
                    CloseTab(tokenTab);
                    ShowTab(loginTab);
                }
            };            
            #endregion

            ShowTab(loginTab);          
        }

        #region helpers
        void ShowTab(Tab tab)
        {
            var fTab = TabsList.FirstOrDefault(t => t.Title.Equals(tab.Title));
            if (fTab == null)
            {
                TabsList.Add(tab);
                Content = tab;
            }
            else
                Content = fTab;
        }

        void AddTab(Tab tab)
        {
            var fTab = TabsList.FirstOrDefault(t => t.Title.Equals(tab.Title));
            if (fTab == null)
            {
                TabsList.Add(tab);                
            }            
        }

        void CloseTab(Tab tab)
        {
            int index = TabsList.IndexOf(tab);
            if (index >= 1)
            {
                var prev = TabsList[index - 1];
                if (prev != null)
                    ShowTab(prev);
            }
            TabsList.Remove(tab);
        }
        #endregion

    }
}
