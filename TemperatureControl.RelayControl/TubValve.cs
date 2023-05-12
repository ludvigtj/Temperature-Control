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
            _relay.TurnOnRelay(4);
        }

        public void CloseValve()
        {
            _relay.TurnOffRelay(4);
        }
    }
}
