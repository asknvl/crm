using Avalonia.Controls;
using crm.Models.api.server;
using crm.Models.user;
using crm.ViewModels.tabs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;

namespace crm.ViewModels
{   
    public class mainVM : ViewModelBase
    {

        #region vars
        homeVM homeTab;
        loginVM loginTab;
        tokenVM tokenTab;
        registrationVM registrationTab;
        BaseServerApi api;
        #endregion

        #region properties      
        public ObservableCollection<Tab> TabsList { get; set; } = new ObservableCollection<Tab>()
        {            
        };

        object? content;
        public object? Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        WindowState windowState;
        public WindowState WindowState { 
            get => windowState; 
            set => this.RaiseAndSetIfChanged(ref windowState, value); 
        }
        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> closeCmd { get; }
        public ReactiveCommand<Unit, Unit> maximizeCmd { get; }
        public ReactiveCommand<Unit, Unit> minimizeCmd { get; }
        public ReactiveCommand<Unit, Unit> homeCmd { get; }
        #endregion
        public mainVM()
        {

            #region dependencies
            api = new ServerApi("http://185.46.9.229:4000");
            #endregion

            #region init
            WindowState = WindowState.Normal;
            #endregion

            #region commands
            closeCmd = ReactiveCommand.Create(() => { });
            maximizeCmd = ReactiveCommand.Create(() => {
                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
                else
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                if (WindowState == WindowState.Minimized)
                    WindowState = WindowState.Maximized;


            });
            minimizeCmd = ReactiveCommand.Create(() => {
                WindowState = WindowState.Normal;
                WindowState = WindowState.Minimized;
            });
            homeCmd = ReactiveCommand.Create(() => {
                //ShowTab(homeTab);
            });
            #endregion

            #region homeTab
            homeTab = new homeVM(this);
            #endregion

            #region registrationTab
            registrationTab = new registrationVM(api, this);
            registrationTab.CloseTabEvent += CloseTab;
            #endregion

            #region loginTab
            loginTab = new loginVM(this);
            loginTab.CloseTabEvent += CloseTab;
            loginTab.onEnterAction += () => {
            };
            loginTab.onCreateUserAction += () =>
            {
                ShowTab(tokenTab);
            };
            #endregion

            #region tokenTab
            tokenTab = new tokenVM(api, this);
            tokenTab.CloseTabEvent += CloseTab;
            tokenTab.onTokenCheckResult += (result, token) =>
            {
                if (result)
                {
                    registrationTab.Token = token;
                    ShowTab(registrationTab);
                }
            };
            #endregion

            ShowTab(homeTab);
            ShowTab(loginTab);          
        }

        #region helpers
        void ShowTab(Tab tab)
        {
            var fTab = TabsList.FirstOrDefault(t => t.Title.Equals(tab.Title));
            if (fTab == null)
            {
                if (tab is homeVM)                
                    TabsList.Insert(0, tab);
                else                
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
