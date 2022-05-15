using crm.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.user
{
    public class Device : ViewModelBase
    {
        int id;
        public int Id {
            get => id;
            set => this.RaiseAndSetIfChanged(ref id, value);
        }

        string name;
        public string Name { 
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        string serial;
        public string Serial
        {
            get => serial;
            set => this.RaiseAndSetIfChanged(ref serial, value);
        }
    }
}
