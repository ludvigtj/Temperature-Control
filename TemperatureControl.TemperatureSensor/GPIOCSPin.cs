using System;
using TemperatureSensor.Interfaces;
using System.Device.Gpio;

namespace TemperatureSensor
{
    public class GPIOCSPin : IGPIOCSPin
    {
        GpioController csPin;
        int _pin;

        public GPIOCSPin(int pin)
        {
            _pin = pin;
            //csPin = new GpioController().OpenPin(pin);
            csPin = new GpioController();
            csPin.OpenPin(_pin, PinMode.Output);
        }

        public void CreateCSPin()
        {
            csPin.SetPinMode(_pin, PinMode.Output);
            csPin.Write(_pin, PinValue.High);
        }

        public void SelectCSPin()
        {
            csPin.Write(_pin, PinValue.Low);
        }

        public void DeselectCSPin()
        {
            csPin.Write(_pin, PinValue.High);
        }
    }
}
