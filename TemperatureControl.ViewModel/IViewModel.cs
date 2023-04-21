using System;

namespace TemperatureControl.ViewModel
{
    internal interface IViewModel
    {
        public void Initialize();
        public void FillButton_Pressed(object sender, EventArgs e);

        public void EmptyButton_Pressed(object sender, EventArgs e);

        public void RegulateButton_Pressed(object sender, EventArgs e);


    }
}
