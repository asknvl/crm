﻿using Avalonia.Data;
using crm.Models.api.server;
using crm.Models.autocompletions;
using crm.Models.user;
using crm.Models.validators;
using crm.ViewModels.dialogs;
using crm.WS;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class loginVM : Tab 
    {
        #region vars
        bool isLogin;       
        bool isPassword;
        IValidator<string> lv = new LoginValidator();
        IAutoComplete la = new EmailAutoComplete();

        IWindowService ws = WindowService.getInstance();
        #endregion

        #region properties       
        string login;        
        public string Login
        {
            get => login;
            set
            {                
                value = la.AutoComplete(value);

                if (needValidate)
                    isLogin = lv.IsValid(value);
                else
                    isLogin = true;

                if (!isLogin)
                    throw new DataValidationException("Введен некорректный e-mail");
                IsInputValid = CheckValidity(new bool[] { isLogin, isPassword });
                this.RaiseAndSetIfChanged(ref login, value);                                                
            }
        }

        string password;
        public string Password
        {
            get => password;
            set {

                if (needValidate)
                    isPassword = value.Length > 0;
                else
                    isPassword = true;

                IsInputValid = CheckValidity(new bool[] { isLogin, isPassword });
                this.RaiseAndSetIfChanged(ref password, value);
            }
        }
        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> enterCmd { get; }
        public ReactiveCommand<Unit, Unit> createCmd { get; }
        public ReactiveCommand<Unit, Unit> forgotCmd { get; }
        #endregion

        public loginVM(BaseServerApi api, ViewModelBase parent) : base(parent)
        {
            Title = "Вход";

            #region dependencies

            #endregion

            #region commands
            enterCmd = ReactiveCommand.CreateFromTask(async () =>
            {
                try
                {
#if ALLOK
                    Login = "asknvl@protonmail.com";
                    Password = "F123qwe$%^0000";
                    BaseUser user = new TestUser();
#else

                    BaseUser user = await api.Login(Login, Password);
#endif
                    if (user != null)
                        onLoginDone?.Invoke(user);

                } catch (Exception ex)
                {
                    ws.ShowDialog(new errMsgVM(ex.Message), Parent);
                }
            });

            createCmd = ReactiveCommand.CreateFromTask(async () => { 
                onCreateUserAction?.Invoke();
            });

            forgotCmd = ReactiveCommand.CreateFromTask(async () => {                 
            });
#endregion
        }

        #region public
        public event Action<BaseUser> onLoginDone;
        public event Action onCreateUserAction;
        public event Action onForgotPasswordAction;

        public override void Clear()
        {            
                needValidate = false;
                Login = "";
                Password = "";
                needValidate = true;            
        }
        #endregion
    }
}
