using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.M5Stack;
using nanoFramework.Presentation;
using nanoFramework.UI;
using TemperatureControl.View;

namespace TemperatureControl.Application
{
    public class Program : nanoFramework.UI.Application
    {
        private static ViewController viewController;
        public static void Main()
        {
            Tough.InitializeScreen();

            Program app = new Program();

            viewController = new ViewController();

            app.Run();
        }
    }
}
