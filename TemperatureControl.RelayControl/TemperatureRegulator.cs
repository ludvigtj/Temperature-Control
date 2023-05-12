using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TemperatureRegulator : ITemperatureRegulator
    {
        public double SetPointTemp { get; set; }

        public double CurrentTemp { get; set; }
        private readonly RelayController _relay;

        public TemperatureRegulator(RelayController relay)
        {
            _relay = relay;
        }

        public void Regulate()
        {
            if (CurrentTemp < SetPointTemp)
            {
                _relay.TurnOnRelay(2); //varmelegeme
            }
            else
            {
                _relay.TurnOffRelay(2);
            }
        }
    }
}
