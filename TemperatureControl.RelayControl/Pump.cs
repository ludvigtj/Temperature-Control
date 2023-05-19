using System.Diagnostics;
using System;
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
            Console.WriteLine("Pumpe tændt");
            Debug.WriteLine("Pumpe tændt");
            _relay.TurnOnRelay(0);
        }

        public void TurnOffPump()
        {
            Console.WriteLine("Pumpe slukket");
            Debug.WriteLine("Pumpe slukket");
            _relay.TurnOffRelay(0);
        }
    }
}
