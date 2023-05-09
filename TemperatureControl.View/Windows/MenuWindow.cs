using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using TemperatureControl.View.Elements;

namespace TemperatureControl.View.Windows
{
    public class MenuWindow : Window
    {
        protected Rectangle[] _touchButtons;
        protected ViewController _viewController;
        public MenuWindow(ViewController controller)
        {
            _viewController = controller;
            this.Visibility = Visibility.Visible;
            this.Width = DisplayControl.ScreenWidth;
            this.Height = DisplayControl.ScreenHeight;
        }

        //Close?
    }
}