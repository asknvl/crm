﻿//#define ALLOK

using crm.Models.api.server;
using crm.Models.appcontext;
using crm.Models.validators;
using crm.ViewModels.dialogs;
using crm.Views.dialogs;
using crm.WS;
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

        #region vars
        bool isToken;
        IWindowService ws = WindowService.getInstance();
        IValidator<string> token_vl = new TokenValidator();
        #endregion

        #region properties
        string token;
        public string Token
        {
            get => token;
            set
            {
                IsInputValid = token_vl.IsValid(value);
                if (!IsInputValid)
                    throw new DataMisalignedException(token_vl.Message);
                this.RaiseAndSetIfChanged(ref token, value);
            }
        }

        #endregion

        #region commands
        public ReactiveCommand<Unit, Unit> continueCmd { get; }
        public ReactiveCommand<Unit, Unit> returnCmd { get; }
        #endregion

        public tokenVM(ApplicationContext appcontext, ViewModelBase parent) : base(parent)
        {
            Title = "Токен";
#if DEBUG
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6NSwicm9sZXMiOlsxLDJdLCJpYXQiOjE2NTA4MzQxMjV9.4zwJ7FjyynpJyhfdknr9PbWAN3HlLAD9nMGDd6Z5oSQ";
#endif

            #region commands
            continueCmd = ReactiveCommand.CreateFromTask(async () =>
            {

#if ALLOK
                onTokenCheckResult?.Invoke(true, Token);
#else

                bool res = false;
                try
                {
                    res = await appcontext.ServerApi.ValidateRegToken(Token);
                    onTokenCheckResult?.Invoke(res, Token);

                } catch (Exception ex)
                {
                    ws.ShowDialog(new errMsgVM(ex.Message), Parent);
                }          
#endif
            });
            returnCmd = ReactiveCommand.Create(() =>
            {
                OnCloseTab();
            });

            #endregion
        }

        #region public
        public event Action<bool, string> onTokenCheckResult;
        public event Action onReturnCmd;

        public override void Clear()
        {            
        }
        #endregion
    }
}
