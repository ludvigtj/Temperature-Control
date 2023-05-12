using System;

namespace TemperatureControl.RelayControl.Interfaces
{
    public interface ITemperatureRegulator
    {
        double SetPointTemp { get; set; }
        double CurrentTemp { get; set; }
        void Regulate();
        void StopRegulate();
    }
}