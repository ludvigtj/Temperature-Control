using System;
using nanoFramework.M5Stack;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.UI;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.View
{
    public class ViewController
    {
        
        private Window _menuWindow;
        private Window _temperatureWindow;
        public ViewController()
        {
            Tough.InitializeScreen();

            if (DisplayControl.IsFullScreenBufferAvailable)
            {
                 _bm = DisplayControl.FullScreen;
            }
            else
            {
                throw new OutOfMemoryException("Insufficient memory for screen functionality");
            } 
            

        }
        
    }
}