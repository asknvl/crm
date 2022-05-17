using Avalonia.Threading;
using crm.Models.api.server;
using crm.Models.appcontext;
using crm.Models.user;
using crm.ViewModels.tabs.home.screens.users;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.screens
{
    public class UserList : BaseScreen
    {
        #region const
        const int update_period = 2000;
        const int displayed_lines_num = 20;
        #endregion

        #region vars
        CancellationTokenSource cts;
        #endregion

        #region properties       
        public override string Title => "Список сотрудников";

        public ObservableCollection<UserListItem> Users { get; set; } = new ObservableCollection<UserListItem>();
        
        int page = 1;
        public int SelectedPage
        {
            get => page;
            set
            {                
                IsPrevActive = (value > 1);
                IsNextActive = (value < TotalPages);
                this.RaiseAndSetIfChanged(ref page, value);
            }
        }

        int totalPages = 0;
        public int TotalPages
        {
            get => totalPages;
            set
            {
                IsPrevActive = (SelectedPage > 1);
                IsNextActive = (SelectedPage < TotalPages || TotalPages == 0);
                this.RaiseAndSetIfChanged(ref totalPages, value);
            }
        }

        int pageSize = displayed_lines_num;
        public int PageSize
        {
            get => pageSize;
            set => this.RaiseAndSetIfChanged(ref pageSize, value);
        }

        bool isNextActive = true;
        public bool IsNextActive
        {
            get => isNextActive;
            set => this.RaiseAndSetIfChanged(ref isNextActive, value);
        }

        bool isPrevActive = true;
        public bool IsPrevActive
        {
            get => isPrevActive;
            set => this.RaiseAndSetIfChanged(ref isPrevActive, value);
        }

        string pageInfo;
        public string PageInfo
        {
            get => pageInfo;
            set => this.RaiseAndSetIfChanged(ref pageInfo, value);
        }
        #endregion

        #region commands
        ReactiveCommand<Unit, Unit> editUserCmd { get; }
        ReactiveCommand<Unit, Unit> showTagsCmd { get; }
        ReactiveCommand<Unit, Unit> showPaspCmd { get; }
        ReactiveCommand<Unit, Unit> nextPageCmd { get; }
        ReactiveCommand<Unit, Unit> prevPageCmd { get; }

        #endregion

        public UserList(ApplicationContext context) : base(context)
        {
            
            SelectedPage = 1;

            #region commands
            editUserCmd = ReactiveCommand.Create(() => {                 
            });

            showTagsCmd = ReactiveCommand.Create(() => { 
            });

            showPaspCmd = ReactiveCommand.Create(() => { 
            });

            prevPageCmd = ReactiveCommand.CreateFromTask(async () => {
                SelectedPage--;
                updatePageInfo(SelectedPage, 20);
            });

            nextPageCmd = ReactiveCommand.CreateFromTask(async () => {
                SelectedPage++;
                updatePageInfo(SelectedPage, 20);
            });
            #endregion
        }

        #region public
        #endregion

        #region helpers
        async Task updatePageInfo(int page, int total)
        {
            await Task.Run(async () => {

                List<User> users;

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    Users.Clear();
                });

                (users, TotalPages) = await AppContext.ServerApi.GetUsers(SelectedPage - 1, 20, AppContext.User.Token);

                foreach (var user in users)
                {
                    var tmp = new UserListItem();
                    tmp.Copy(user);
                    await Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        Users.Add(tmp);
                    });
                }

            });            
        }
        #endregion

        #region override
        public override async void OnActivate()
        {

            //AppContext.TabService.ShowTab(new loginVM(AppContext ,this));

            base.OnActivate();


            cts = new CancellationTokenSource();

            BaseServerApi api = AppContext.ServerApi;
            string token = AppContext.User.Token;

            updatePageInfo(SelectedPage, 20);            

            try
            {
                await Task.Run(async () =>
                {

                    while (true)
                    {

                        //List<User> users;
                        //(users, TotalPages) = await AppContext.ServerApi.GetUsers(SelectedPage - 1, 20, AppContext.User.Token);

                        //if (users.Count != Users.Count)
                        //{
                        //    await Dispatcher.UIThread.InvokeAsync(() =>
                        //    {
                        //        Users.Clear();
                        //    });
                        //}

                        //foreach (var user in users)
                        //{
                        //    var found = Users.FirstOrDefault(u => u.Id == user.Id);
                        //    if (found != null)
                        //    {
                        //        found.Copy(user);
                        //    } else
                        //    {
                        //        var tmp = new UserListItem();
                        //        tmp.Copy(user);
                        //        await Dispatcher.UIThread.InvokeAsync(() =>
                        //        {
                        //            Users.Add(tmp);
                        //        });
                        //    }
                        //}

                        //Thread.Sleep(1000);
                    }

                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());
                    //Users.Add(new UserItemTest());



                    //while (true)
                    //{
                    //    cts.Token.ThrowIfCancellationRequested();
                    //    Debug.WriteLine("!!!");
                    //    Thread.Sleep(update_period);
                    //}

                });

            }
            catch (OperationCanceledException ex)
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
