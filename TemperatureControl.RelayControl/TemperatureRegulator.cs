﻿using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TemperatureRegulator : ITemperatureRegulator
    {
        public double SetPointTemp { get; set; }

        public double CurrentTemp { get; set; }
        private readonly IRelayController _relay;

        public TemperatureRegulator(IRelayController relay)
        {
            _relay = relay;
        }

        public void Regulate()
        {
            if (CurrentTemp < SetPointTemp)
            {
                _relay.TurnOnRelay(2); //varmelegeme
            }
            else
            {
                _relay.TurnOffRelay(2);
            }
        }

        public void StopRegulate()
        {
            throw new System.NotImplementedException();
        }
    }
}
