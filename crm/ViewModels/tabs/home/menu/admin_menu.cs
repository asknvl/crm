using crm.Models.appcontext;

namespace crm.ViewModels.tabs.home.menu
{
    public class admin_menu : BaseMenu
    {
        public admin_menu(ApplicationContext appcontext) : base(appcontext)
        {

            SimpleMenuItem dashboard = new items.Dashboard();
            dashboard.AddScreen(new screens.Dashboard());                        
            AddItem(dashboard);

            ComplexMenuItem users = new items.Users();            
            users.AddScreen(new screens.UserList(appcontext));
            users.AddScreen(new screens.UserActions());            
            AddItem(users);

            SimpleMenuItem accimport = new items.AccountsImport();
            accimport.AddScreen(new screens.AccountsImport());
            AddItem(accimport);

            SimpleMenuItem creatives = new items.Creatives();
            creatives.AddScreen(new screens.Creatives());
            AddItem(creatives);

            SimpleMenuItem subscriptions = new items.Subscriptions();
            subscriptions.AddScreen(new screens.Subscriptions());
            AddItem(subscriptions);

            ComplexMenuItem proxies = new items.Proxies();
            proxies.AddScreen(new screens.TBD());
            proxies.AddScreen(new screens.TBD());
            AddItem(proxies);

            SimpleMenuItem devices = new items.Devices();
            devices.AddScreen(new screens.Devices());
            AddItem(devices);

            SimpleMenuItem geo = new items.GEO();
            geo.AddScreen(new screens.GEO());
            AddItem(geo);

            ComplexMenuItem finances = new items.Finances();
            finances.AddScreen(new screens.Bills());
            finances.AddScreen(new screens.Expenses());
            AddItem(finances);

            ComplexMenuItem accounts = new items.Accounts();
            accounts.AddScreen(new screens.TBD());
            accounts.AddScreen(new screens.TBD());
            AddItem(accounts);
        }
        
    }
}
