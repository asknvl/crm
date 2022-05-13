using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs.home.screens
{
    public class UserList : BaseScreen
    {
        #region properties
        public override string Title => "Список сотрудников";
        #endregion

        public UserList()
        {
        }

        #region public
        #endregion

        #region override
        public override void OnActivate()
        {            
            base.OnActivate();
        }
        public override void OnDeactivate()
        {            
            base.OnDeactivate();
        }
        #endregion
    }
}
