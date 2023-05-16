using System;
using System.Diagnostics;
using nanoFramework.M5Stack;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Tough;
using nanoFramework.UI;
using TemperatureControl.ViewModel;
using TemperatureControl.ViewModel.Interfaces;
using TemperatureControl.ViewModel.Windows;
using TouchButton = TemperatureControl.View.Elements.TouchButton;

namespace TemperatureControl.View
{
    public class ViewController : IViewController
    {
        private MenuWindow ActiveWindow;
        public IViewModel ViewModel { get; }

        public ViewController(IViewModel view)
        {
            
            


        }

        private void ToughOnTouchEvent(object sender, TouchEventArgs e)
        {
            
        }

        
    }
}