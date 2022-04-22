using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class loginVM : Tab 
    {
        #region properties
        string login;
        public string Login
        {
            get => login;
            set => this.RaiseAndSetIfChanged(ref login, value); 
        }

        string password;
        public string Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);

        }
        #endregion

        #region commands
        ReactiveCommand<Unit, Unit> enterCmd { get; }
        ReactiveCommand<Unit, Unit> createCmd { get; }
        ReactiveCommand<Unit, Unit> forgotCmd { get; }
        #endregion

        public loginVM()
        {
            Title = "Вход";

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
