using System;
using nanoFramework.Presentation.Shapes;

namespace TemperatureControl.View.Elements
{
    public class TouchButton: Rectangle, ITouchButton
    {
        public event EventHandler ButtonPressed;

        public TouchButton(int height, int width):base(width,height)
        {
            
        }

        public void Press()
        {
            OnButtonPressed();
        }

        protected void OnButtonPressed()
        {
            EventHandler handler = ButtonPressed;
            if (handler == null) return;
            handler.Invoke(this, EventArgs.Empty);

        }
    }
}