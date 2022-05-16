using crm.Models.appcontext;
using crm.Models.user;
using crm.ViewModels.tabs.home.screens.users;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.screens
{
    public class UserList : BaseScreen
    {
        #region vars
        CancellationTokenSource cts;
        #endregion
        #region properties
        ApplicationContext AppContext { get; }
        public override string Title => "Список сотрудников";

        public ObservableCollection<UserListItem> Users { get; set; } = new ObservableCollection<UserListItem>();
        
        int page;
        public int SelectedPage
        {
            get => page;
            set => this.RaiseAndSetIfChanged(ref page, value);
        }

        int pages;
        public int TotalPages
        {
            get => pages;
            set => this.RaiseAndSetIfChanged(ref pages, value);
        }
        #endregion

        public UserList(ApplicationContext appcontext)
        {
            AppContext = appcontext;
            SelectedPage = 1;
        }

        #region public
        #endregion

        #region override
        public override async void OnActivate()
        {

            base.OnActivate();

            cts = new CancellationTokenSource();

            try
            {
                await Task.Run(async () =>
                {


                    

                    List<User> users;
                    int total_pages = 0;

                    (users, total_pages) = await AppContext.ServerApi.GetUsers(1, 20, AppContext.User.Token);

                    Users.Clear();

                    foreach (var user in users)
                    {
                        Users.Add();
                    }

                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());



                    while (true)
                    {

                        cts.Token.ThrowIfCancellationRequested();

                        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {

                        });
                        

                        Debug.WriteLine("!!!");
                        Thread.Sleep(1000);
                    }

                });

            } catch (OperationCanceledException ex)
            {
            }
        }
        public override void OnDeactivate()
        {
            cts?.Cancel();
            base.OnDeactivate();
        }
        #endregion
    }
}
