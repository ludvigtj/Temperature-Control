using System;

namespace TemperatureControl.ViewModel.Interfaces
{
    public interface ITouchButton
    {
        public event EventHandler ButtonPressed;
        public void Press();
    }
}