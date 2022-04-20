using crm.ViewModels.tabs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace crm.ViewModels
{   
    public class mainVM : ViewModelBase
    {

        public List<Tab> TestList { get; set; } = new List<Tab>() { 
            new loginVM()            
        };

        object? content;
        public object? Content 
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

    }
}
