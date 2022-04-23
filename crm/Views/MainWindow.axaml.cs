using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace crm.Views
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {            
            InitializeComponent();
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            BeginMoveDrag(e);
        }
        
    }
}
