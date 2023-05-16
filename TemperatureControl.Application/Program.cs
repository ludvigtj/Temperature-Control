using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.M5Stack;
using nanoFramework.Presentation;
using nanoFramework.UI;
using TemperatureControl.View;
using TemperatureControl.ViewModel;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.Application
{
    public class Program : nanoFramework.UI.Application
    {
        private static WindowModel viewModel;
        public static void Main()
        {
            Tough.InitializeScreen();

            Program app = new Program();
            viewModel = new WindowModel();

            app.Run();
        }
    }
}
