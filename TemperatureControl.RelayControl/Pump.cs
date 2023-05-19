using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class Pump : IPump
    {
        private readonly IRelayController _relay;
        public Pump(IRelayController relay)
        {
            _relay = relay;
        }
        public void TurnOnPump()
        {
            _relay.TurnOnRelay(0);
        }

        public void TurnOffPump()
        {
            _relay.TurnOffRelay(0);
        }
    }
}
