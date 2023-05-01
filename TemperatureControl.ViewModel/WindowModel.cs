using nanoFramework.UI;
using System;
using TemperatureControl.Model;
using TemperatureControl.ViewModel.Abstract;
using System.ComponentModel;

namespace TemperatureControl.ViewModel
{
    public class WindowModel : IViewModel, INotifyPropertyChanged
    {
        private BusinessLogic _logic;
        private enum States
        {
            STANDBY, ALARM, FILLING, REGULATE, EMPTYING
        }
        private States _state = States.STANDBY;

        public event PropertyChangedEventHandler? PropertyChanged;

        private double _setPointTemperature;
        public double SetPointTemperature
        {
            get { return _setPointTemperature; }
            set
            {
                _setPointTemperature = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SetPointTemperature)));
            }
        }

        public WindowModel()
        {
            _logic = new BusinessLogic();
            SetPointTemperature = 36.5;
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
            // Viser at fyld funktion er aktiv
            _logic.FillVessel();
            // Viser at fyld funktionen er inaktiv og reguler funktionen er aktiv

            // Viser at reguler funktion er inaktiv efter 5 timer
        }

        public void OnRegulate_Pressed(object sender, EventArgs e)
        {
            _logic.RegulateTemperature(SetPointTemperature);  // skal databindes med displayet.
            // Viser at regulering er aktiv

            // Efter 5 timer, viser at reguleringen er inaktiv

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
