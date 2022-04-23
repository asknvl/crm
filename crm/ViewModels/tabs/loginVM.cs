using Avalonia.Data;
using crm.Models.autocompletions;
using crm.Models.validators;
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
        #endregion
        #region properties       
        string login;        
        string Login
        {
            get => login;
            set
            {
                value = la.AutoComplete(value);              
                isLogin = lv.IsValid(value);
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
                isPassword = value.Length > 0;
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

        public loginVM()
        {
            Title = "Вход";

            #region dependencies
           
            #endregion

            #region commands
            enterCmd = ReactiveCommand.CreateFromTask(async () => {
                //отправляет логин, пароль
                //получает токен
                
            });

            createCmd = ReactiveCommand.CreateFromTask(async () => {
                //отправляет токен, получает одобрение от сервера и права доступа                
                onCreateUserAction?.Invoke();
            });

            forgotCmd = ReactiveCommand.CreateFromTask(async () => {                 
            });
            #endregion
        }

        #region public
        public event Action onEnterAction;
        public event Action onCreateUserAction;
        public event Action onForgotPasswordAction;
        #endregion
    }
}
