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
            new testTabVM() { Title = "������� 1", Description = "�������� 1" },
            new testTabVM() { Title = "������� 2", Description = "�������� 2" }
        };

        object? content;
        public object? Content 
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

    }
}
