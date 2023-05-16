using System;
using nanoFramework.UI;
using TemperatureControl.View.Elements;

namespace TemperatureControl.ViewModel.Interfaces
{
    public interface IViewModel
    {
        public void Initialize();
        public TouchButton[] ActiveButtons { get; set; }
        public event EventHandler WindowClosed;
        public event PropertyChangedEventHandler? SetPointChanged;
        public event PropertyChangedEventHandler? ReadTempChanged;
        public void OnArrow_Pressed(object sender, EventArgs e);
        public void OnSetPointPlus_Pressed(object sender, EventArgs e);
        public void OnSetPointMinus_Pressed(object sender, EventArgs e);
        public void OnFill_Pressed(object sender, EventArgs e);
        public void OnEmpty_Pressed(object sender, EventArgs e);
        public void OnRegulate_Pressed(object sender, EventArgs e);




    }
}
