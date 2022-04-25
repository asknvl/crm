using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace crm.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public event Action onCloseRequest;
        public void OnCloseRequest()
        {
            onCloseRequest?.Invoke();
        }
    }
}
