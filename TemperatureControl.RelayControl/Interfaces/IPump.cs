namespace TemperatureControl.RelayControl.Interfaces
{
    public interface IPump
    {
        bool PumpOn { get; }
        void TurnOnPump();
        void TurnOffPump();
    }
}