using System;
using System.Collections;
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
            CheckTemperature();
            regulatingSubscribe = new ArrayList();
            alarmSubscribe = new ArrayList();
            emptySubscribe = new ArrayList();
            fillingSubscribe = new ArrayList();
            standbySubscribe = new ArrayList();
            //_logic = new BusinessLogic();
            mainWindow = new MainMenuWindow(this);
        }

        public event EventHandler? WindowClosed;
    }
}
