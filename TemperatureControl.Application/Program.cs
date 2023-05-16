using nanoFramework.M5Stack;
using TemperatureControl.ViewModel;

namespace TemperatureControl.Application
{
    public class Program : nanoFramework.UI.Application
    {
        private static WindowModel viewModel;
        public static void Main()
        {
            Tough.InitializeScreen();
            viewModel = new WindowModel();
            Program app = new Program();
            app.Run();
        }
    }
}
