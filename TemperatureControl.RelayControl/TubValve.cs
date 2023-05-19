using System.Diagnostics;
using System;
using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TubValve : IValve
    {
        private readonly IRelayController _relay;
        public TubValve(IRelayController relay)
        {
            _relay = relay;
        }

        public void OpenValve()
        {
            Console.WriteLine("Ventil til kar åben");
            Debug.WriteLine("Ventil til kar åben");
            _relay.TurnOnRelay(3);
        }

        public void CloseValve()
        {
            Console.WriteLine("Ventil til kar lukket");
            Debug.WriteLine("Ventil til kar lukket");
            _relay.TurnOffRelay(3);
        }
    }
}
