using nanoFramework.UI;
using System;
using TemperatureControl.View.Elements;

namespace TemperatureControl.ViewModel.Interfaces
{
    public interface IViewModel
    {
        public event EventHandler WindowClosed;
        public event PropertyChangedEventHandler? SetPointChanged;
        public event PropertyChangedEventHandler? ReadTempChanged;
        public void Subscribe(TouchButton tb, States state);
        public void OnSetPointPlus_Pressed(object sender, EventArgs e);
        public void OnSetPointMinus_Pressed(object sender, EventArgs e);
        public void OnFill_Pressed(object sender, EventArgs e);
        public void OnEmpty_Pressed(object sender, EventArgs e);
        public void OnRegulate_Pressed(object sender, EventArgs e);

    }
}
