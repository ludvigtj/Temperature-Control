using System;

namespace TemperatureSensor.Interfaces
{

    public interface IGPIOCSPin
    {
        void CreateCSPin();
        void SelectCSPin();
        void DeselectCSPin();

    }
}



