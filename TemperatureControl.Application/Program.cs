using nanoFramework.M5Stack;
using nanoFramework.UI;
using RelayControl;
using System.Device.I2c;
using System.Threading;
using Iot.Device.Relay;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.ViewModel;
using TemperatureControl.ViewModel.Windows;

namespace TemperatureControl.Application
{
    public class Program : nanoFramework.UI.Application
    {
        //private static WindowModel viewModel;
        private static TestMethodInvoker invoker;
        public static void Main()
        {
            Tough.InitializeScreen();
            invoker = new TestMethodInvoker();

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
