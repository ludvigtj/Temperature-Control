using System;

namespace TemperatureControl.View.Elements
{
    public interface ITouchButton
    {
        public event EventHandler ButtonPressed;
        public void Press();
    }
}