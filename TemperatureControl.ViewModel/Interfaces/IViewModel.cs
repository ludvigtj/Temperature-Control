using System;

namespace TemperatureControl.ViewModel.Interfaces
{
    internal interface IViewModel
    {
        public void Initialize();

        public void OnArrow_Pressed(object sender, EventArgs e);
        public void OnSetPointPlus_Pressed(object sender, EventArgs e);
        public void OnSetPointMinus_Pressed(object sender, EventArgs e);
        public void OnFill_Pressed(object sender, EventArgs e);
        public void OnEmpty_Pressed(object sender, EventArgs e);
        public void OnRegulate_Pressed(object sender, EventArgs e);




    }
}
