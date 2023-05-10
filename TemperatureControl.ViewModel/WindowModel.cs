﻿using nanoFramework.UI;
using System;
using System.ComponentModel;
using System.Threading;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel
{
    public class WindowModel : IViewModel
    {
        private BusinessLogic _logic;
        private Thread checkTempThread;
        private enum States
        {
            STANDBY, ALARM, FILLING, REGULATING, EMPTYING
        }
        private States _state = States.STANDBY;

        public WindowModel(BusinessLogic logic)
        {
            _logic = logic;
            //_logic = new BusinessLogic();
            _logic.SetPointTemperature = 36.5;
            checkTempThread = new Thread(_logic.CheckTemperature);
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void OnArrow_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CheckTemperature()
        {
            if (!checkTempThread.IsAlive)
            {
                checkTempThread.Start();
            }
        }

        public void OnEmpty_Pressed(object sender, EventArgs e)
        {
            if (_state != States.FILLING && _state != States.EMPTYING)
            {
                // Viser at reguler er inaktiv og tømfunktionen er aktiv
                _logic.EmptyVessel();
                _state = States.EMPTYING;
                // Viser at tømfunktionen er inaktiv
            }
            else
            {
                throw new Exception("Filling is active");
            }
        }

        public void OnFill_Pressed(object sender, EventArgs e)
        {
            if (_state == States.STANDBY)
            {
                // Viser at fyld funktion er aktiv
                _logic.FillVessel();
                _state = States.FILLING;
                // Viser at fyld funktionen er inaktiv og reguler funktionen er aktiv

                // Viser at reguler funktion er inaktiv efter 5 timer
            }
            else
            {
                throw new Exception("Tub is not empty");
            }
        }

        public void OnRegulate_Pressed(object sender, EventArgs e)
        {
            if (_state == States.STANDBY)
            {
                _logic.RegulateTemperature(); 
                _state = States.REGULATING;
                // Viser at regulering er aktiv

                // Efter 5 timer, viser at reguleringen er inaktiv
            }
            else
            {
                throw new Exception("Tub is either filling or emptying");
            }
        }

        public void OnSetPointMinus_Pressed(object sender, EventArgs e)
        {
            _logic.SetPointTemperature -= 0.5;
        }

        public void OnSetPointPlus_Pressed(object sender, EventArgs e)
        {
            _logic.SetPointTemperature += 0.5;
        }
    }
}
