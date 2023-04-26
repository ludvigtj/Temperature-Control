using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class Pump : IPump
    {
        private readonly IRelayController _relay;
        public bool PumpOn { get; private set; } = false;
        public Pump(IRelayController relay)
        {
            _relay = relay;
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
