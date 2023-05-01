using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class Pump : IPump
    {
        private readonly IRelayController _relay;
        public bool PumpOn { get; private set; }
        public Pump(IRelayController relay)
        {
            _relay = relay;
            PumpOn = false;
        }
        public void TurnOnPump()
        {
            _relay.TurnOnRelay(1);
            PumpOn = true;
        }

        public void TurnOffPump()
        {
            _relay.TurnOffRelay(1);
            PumpOn = false;
        }
    }
}
