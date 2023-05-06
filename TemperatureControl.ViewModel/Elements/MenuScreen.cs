using nanoFramework.M5Stack;

namespace TemperatureControl.ViewModel.Elements
{
    public class MenuScreen
    {
        private DrawableObject[] _items;
        public Menu Type { get; }

        public MenuScreen(Menu type)
        {

        }
    }



    public enum Menu
    {
        Functions,
        Configure
    }
}