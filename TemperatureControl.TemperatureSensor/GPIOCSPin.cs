using System;
using TemperatureSensor.Interfaces;
using System.Device.Gpio;

namespace TemperatureSensor
{
    public class GPIOCSPin : IGPIOCSPin
    {
        GpioPin csPin;

        public GPIOCSPin(int pin)
        {
            csPin = new GpioController().OpenPin(pin);
        }

        public void CreateCSPin()
        {
            csPin.SetPinMode(PinMode.Output);
            csPin.Write(PinValue.High);
        }

        public void SelectCSPin()
        {
            csPin.Write(PinValue.Low);
        }

        public void DeselectCSPin()
        {
            csPin.Write(PinValue.High);
        }
    }
}
