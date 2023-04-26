using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class Pump : IPump
    {
        private readonly RelayController _relay;

        public Pump(RelayController relay)
        {
            _relay = relay;
        }
        public void TurnOnPump()
        {
            _relay.TurnOnRelay(1);
        }

        public void TurnOffPump()
        {
            _relay.TurnOffRelay(1);
        }
    }
}
