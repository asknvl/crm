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
        Grid cg;
        Button _b1, _b2, _b3;
        bool isCGchecked = false;

        public MainWindow()
        {            
            InitializeComponent();

            cg = this.FindControl<Grid>("CG");
            cg.Background = new SolidColorBrush(0xFF2C2C2C);
            cg.PointerPressed += Cg_PointerPressed;
            cg.PointerEnter += Cg_PointerEnter;
            cg.PointerLeave += Cg_PointerLeave;

            _b1 = this.FindControl<Button>("b1");
            _b1.PointerEnter += _b1_PointerEnter;
            _b2 = this.FindControl<Button>("b2");
            _b3 = this.FindControl<Button>("b3");


        }

        private void _b1_PointerEnter(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            //if (!isCGchecked)
            //    _b1.BorderThickness = new Thickness(1.5);
        }

        private void Cg_PointerLeave(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            colorButtons(false);
        }

        private void Cg_PointerEnter(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            colorButtons(IsActive);
        }

        private void Cg_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            //isCGchecked = !isCGchecked;
            //cg.Background = (isCGchecked) ? new SolidColorBrush(0xFF212121) : new SolidColorBrush(0xFF2C2C2C);
            //colorButtons(isCGchecked);

        }

        private void colorButtons(bool state)
        {

            if (state)
            {
                _b1.BorderThickness = new Thickness(0);
                _b1.Background = new SolidColorBrush(0xFFFF5B55);
                _b2.BorderThickness = new Thickness(0);
                _b2.Background = new SolidColorBrush(0xFFFEBA32);
                _b3.BorderThickness = new Thickness(0);
                _b3.Background = new SolidColorBrush(0xFF27C840);
            }
            else
            {

                _b1.BorderThickness = new Thickness(1.5);
                _b1.Background = new SolidColorBrush(0);
                _b2.BorderThickness = new Thickness(1.5);
                _b2.Background = new SolidColorBrush(0);
                _b3.BorderThickness = new Thickness(1.5);
                _b3.Background = new SolidColorBrush(0);
            }
        }

        private void checkCG(bool state)
        {
            cg.Background = (state) ? new SolidColorBrush(0xFF212121) : new SolidColorBrush(0xFF2C2C2C);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            BeginMoveDrag(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            isCGchecked = false;
            checkCG(isCGchecked);
        }

        protected override void OnGotFocus(GotFocusEventArgs e)
        {
            base.OnGotFocus(e);
            isCGchecked = true;
            checkCG(isCGchecked);

        }
    }
}
