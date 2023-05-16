using System;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using TemperatureControl.View.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public abstract class MenuWindow : Window
    {
        protected static TouchButton[] TouchButtons;
        protected static IViewModel viewModel;
        public TouchButton[] LocalButtons;

        public MenuWindow(IViewModel model)
        {
            model.WindowClosed += OnSwitchWindows;
            TouchButtons = ButtonContainer.Buttons;
            if (TouchButtons.Length < 1)
            {
                throw new InvalidOperationException("TouchButtons not set");
            }
            viewModel = model;
            this.Visibility = Visibility.Visible;
            this.Width = DisplayControl.ScreenWidth;
            this.Height = DisplayControl.ScreenHeight;
        }

        public void OnSwitchWindows(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}