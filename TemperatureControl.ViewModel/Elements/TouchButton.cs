using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using System;
using nanoFramework.Presentation.Controls;
using TemperatureControl.ViewModel;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Elements
{
    public class TouchButton : Rectangle, ITouchButton
    {
        public TouchButton(int x, int y) : base(x, y) { }

        private static SolidColorBrush greenFill = new SolidColorBrush(Color.Green);
        
        private static SolidColorBrush blackFill = new SolidColorBrush(Color.Black);

        public event EventHandler ButtonPressed;
        public void Press()
        {
            EventHandler handler = ButtonPressed;
            if (handler == null) return;
            handler.Invoke(this, EventArgs.Empty);
        }

    }
}