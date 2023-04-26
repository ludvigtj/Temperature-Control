﻿using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class TubValve : IValve
    {
        private readonly RelayController _relay;
        public TubValve(RelayController relay)
        {
            _relay = relay;
        }
        public void OpenValve()
        {
            _relay.TurnOnRelay(4);
        }

        public void CloseValve()
        {
            _relay.TurnOffRelay(4);
        }
    }
}