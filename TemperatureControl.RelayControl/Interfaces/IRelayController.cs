using System;

namespace RelayControl.Interfaces
{
    public interface IRelayController
    {
        void TurnOnRelay(byte number);
        void TurnOffRelay(byte number);
    }
}