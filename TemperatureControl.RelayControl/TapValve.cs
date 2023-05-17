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
            _relay.TurnOnRelay(3);
        }

        public void CloseValve()
        {
            _relay.TurnOffRelay(3);
        }
    }
}
