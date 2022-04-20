using crm.ViewModels.tabs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace crm.ViewModels
{   
    public class mainVM : ViewModelBase
    {

        public List<object> TestList { get; set; } = new List<object>() { 
            new testTabVM() { Title = "Вкладка 1", Description = "Описание 1" },
            new testTabVM() { Title = "Вкладка 2", Description = "Описание 2" }
        };

        object? content;
        public object? Content 
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

    }
}
