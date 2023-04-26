using System;
using TemperatureControl.ViewModel.Abstract;
using TemperatureControl.Model;

namespace TemperatureControl.ViewModel
{
    public class WindowModel : IViewModel
    {
        private BusinessLogic _logic;
        private enum States
        {
            STANDBY, ALARM, FILLING, REGULATE, EMPTYING
        }
        private States _state = States.STANDBY;
        
        public WindowModel()
        {
            _logic = new BusinessLogic();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void OnArrow_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnEmpty_Pressed(object sender, EventArgs e)
        {
            if (_state != States.FILLING)
            {
                // Viser at reguler er inaktiv og tømfunktionen er aktiv
                _logic.EmptyVessel();
                // Viser at tømfunktionen er inaktiv
            }
            else
            {
                throw new Exception("Filling is active");
            }
        }

        public void OnFill_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnRegulate_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnSetPointMinus_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnSetPointPlus_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
