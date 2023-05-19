using System;
using System.Diagnostics;
using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TemperatureRegulator : ITemperatureRegulator
    {
        public double SetPointTemp { get; set; }
        public double CurrentTemp { get; set; }
        private readonly IRelayController _relay;
        private bool isOn = false;

        public TemperatureRegulator(IRelayController relay)
        {
            _relay = relay;
        }

        public void Regulate()
        {
            if (CurrentTemp < SetPointTemp - 0.2)
            {
                if (!isOn)
                {
                    _relay.TurnOnRelay(1); //varmelegeme
                    isOn = true;
                    Console.WriteLine("Temperaturregulering startet");
                    Debug.WriteLine("Temperaturregulering startet");
                }
            }
            else if (CurrentTemp > SetPointTemp + 0.2)
            {
                if (isOn)
                {
                    _relay.TurnOffRelay(1);
                    isOn = false;
                    Console.WriteLine("Temperaturregulering slukket");
                    Debug.WriteLine("Temperaturregulering slukket");
                }
            }
        }
        public void StopRegulate()
        {
            if (isOn)
            {
                _relay.TurnOffRelay(1);
                Console.WriteLine("Temperaturregulering slukket");
                Debug.WriteLine("Temperaturregulering slukket");
            }
        }
    }
}
