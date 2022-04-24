using crm.Models.api.server;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class tokenVM : Tab
    {
        #region properties
        string token;
        public string Token
        {
            get => token;
            set => this.RaiseAndSetIfChanged(ref token, value);
        }
        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> continueCmd { get; }
        public ReactiveCommand<Unit, Unit> returnCmd { get; }
        #endregion

        public tokenVM(BaseServerApi api)
        {
            Title = "Токен";

            #region commands
            continueCmd = ReactiveCommand.CreateFromTask(async () => {
                bool res = await api.ValidateRegToken(Token);
                if (res)
                {
                    onTokenCheckResult?.Invoke(true);
                    //OnCloseTab();
                } else { 

                }                
            });            
            returnCmd = ReactiveCommand.Create(() => {
                OnCloseTab();
            });
            #endregion
        }

        #region public
        public event Action<bool> onTokenCheckResult;
        public event Action onReturnCmd;
        #endregion
    }
}
