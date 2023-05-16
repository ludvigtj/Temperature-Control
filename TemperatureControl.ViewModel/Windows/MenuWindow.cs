using nanoFramework.Presentation;
using nanoFramework.Tough;
using nanoFramework.UI;
using System;
using TemperatureControl.View.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public abstract class MenuWindow : Window
    {
        protected static IViewModel viewModel;
        public TouchButton[] tbMenu;
        public MenuWindow(IViewModel model)
        {
            model.WindowClosed += OnSwitchWindows;
            viewModel = model;
            this.Visibility = Visibility.Visible;
            this.Width = DisplayControl.ScreenWidth;
            this.Height = DisplayControl.ScreenHeight;
            DefineRenders();
        }

        protected abstract void OnSwitchWindows(object sender, EventArgs e);

        protected abstract void DefineRenders();

        public virtual void ToughOnTouchEvent(object sender, TouchEventArgs e)
        {
            foreach (TouchButton localButton in tbMenu)
            {
                if (localButton.ButtonRender.ContainsPoint(e.X, e.Y))
                {
                    localButton.Press();
                }
            }
        }
    }
}