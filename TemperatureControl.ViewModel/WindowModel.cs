using System;
using TemperatureControl.ViewModel.Interfaces;
using TemperatureControl.ViewModel.Windows;

namespace TemperatureControl.ViewModel
{
    public enum States
    {
        STANDBY = 0, ALARM = 1, FILLING = 2, REGULATING = 3, EMPTYING = 4
    }

    public partial class WindowModel : IViewModel
    {
        private BusinessLogic _logic;
        static MenuWindow mainWindow;

        public WindowModel()
        {
            //_logic = new BusinessLogic();
            mainWindow = new MainMenuWindow(this);
        }

        public event EventHandler? WindowClosed;
    }
}
