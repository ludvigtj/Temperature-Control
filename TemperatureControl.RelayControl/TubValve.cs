using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TubValve : IValve
    {
        private readonly IRelayController _relay;
        public bool ValveOpen { get; private set; }
        public TubValve(IRelayController relay)
        {
            _relay = relay;
            ValveOpen = false;
        }

        public void OpenValve()
        {
            _relay.TurnOnRelay(4);
            ValveOpen = true;
        }

        public void CloseValve()
        {
            _relay.TurnOffRelay(4);
            ValveOpen = false;
        }
    }
}
