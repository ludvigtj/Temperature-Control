using nanoFramework.M5Stack;
using nanoFramework.UI;
using RelayControl;
using System.Device.I2c;
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
            Program app = new Program();
            invoker = new TestMethodInvoker();
            app.Run();
        }
    }
}
