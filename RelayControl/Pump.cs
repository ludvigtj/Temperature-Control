using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class Pump : IPump
    {
        private readonly RelayControl _relay;

        public Pump(RelayControl relay)
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
