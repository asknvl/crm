using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.ViewModels.tabs
{
    public class homeVM : Tab
    {
        public homeVM(ViewModelBase parent) : base(parent)
        {
            Title = "Домой";
        }
    }
}
