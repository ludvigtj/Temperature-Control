using System;

namespace RelayControl.Interfaces
{
    public interface ITemperatureRegulator
    {
        double SetPointTemp { get; set; }
        void Regulate(double actualTemp);

    }
}
