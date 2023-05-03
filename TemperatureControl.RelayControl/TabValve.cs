using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TabValve: IValve
    {
        private readonly IRelayController _relay;
        public bool ValveOpen { get; private set; }
        public TabValve(IRelayController relay)
        {
            _relay = relay;
            ValveOpen = false;
        }
        
        public void OpenValve()
        {
            _relay.TurnOnRelay(3);
            ValveOpen = true;
        }

        public void CloseValve()
        {
            _relay.TurnOffRelay(3);
            ValveOpen = false;
        }
    }
}
