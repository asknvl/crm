﻿using crm.Models.api.server;
using crm.Models.user;
using crm.ViewModels.tabs.home.menu;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class homeVM : Tab
    {
        #region vars
        BaseServerApi api;
        #endregion

        #region properties     
        BaseMenu menu;
        public BaseMenu Menu
        {
            get => menu;
            set => this.RaiseAndSetIfChanged(ref menu, value);
        }
        //object screen;
        //public object Screen
        //{
        //    get => screen;
        //    set => this.RaiseAndSetIfChanged(ref screen, value);
        //}

        BaseUser user;
        BaseUser User
        {
            get => user;            
            set => this.RaiseAndSetIfChanged(ref user, value);                         
            
        }

        string initialLetter;
        public string InitialLetter
        {
            get => initialLetter;
            set => this.RaiseAndSetIfChanged(ref initialLetter, value);
        }

        bool isProfileMenuOpen;
        public bool IsProfileMenuOpen
        {
            get => isProfileMenuOpen;
            set {
                isProfileMenuOpen = value;
                this.RaisePropertyChanged("IsProfileMenuOpen");
            }
        }

        #endregion

        #region commands        
        public ReactiveCommand<Unit, Unit> profileMenuOpenCmd { get; }
        public ReactiveCommand<Unit, Unit> addUserCmd { get; }
        public ReactiveCommand<Unit, Unit> quitCmd { get; }
        #endregion

        public homeVM() : base(null)
        {
            Menu = new admin_menu();
        }

        public homeVM(BaseServerApi api, BaseUser user, ViewModelBase parent) : base(parent)
        {


            #region commands
            profileMenuOpenCmd = ReactiveCommand.Create(() => {                        
                IsProfileMenuOpen = true;
            });

            addUserCmd = ReactiveCommand.Create(() =>
            {
                AddUserEvent?.Invoke();
            });

            quitCmd = ReactiveCommand.Create(() =>
            {
                OnCloseTab();
            });
            #endregion

            this.api = api;
            User = user;                        
            Title = "Домой";

            Menu = new admin_menu();
            
        }

        #region public
        public event Action AddUserEvent;

        public override void Clear()
        {            
        }
        #endregion
    }
}
