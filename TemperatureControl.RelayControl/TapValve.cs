using System;
using System.Diagnostics;
using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TapValve: IValve
    {
        private readonly IRelayController _relay;
        public TapValve(IRelayController relay)
        {
            _relay = relay;
        }

        public void OpenValve()
        {
            Console.WriteLine("Ventil til brugsvand åben");
            Debug.WriteLine("Ventil til brugsvand åben");
            _relay.TurnOnRelay(2);
        }

        public void CloseValve()
        {
            Console.WriteLine("Ventil til brugsvand lukket");
            Debug.WriteLine("Ventil til brugsvand lukket");
            _relay.TurnOffRelay(2);
        }
    }
}
