using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TemperatureRegulator :ITemperatureRegulator
    {
        public double SetPointTemp { get; set; }

        private double _actualTemp;
        private readonly IRelayController _relay;

        public TemperatureRegulator(IRelayController relay)
        {
            _relay = relay;
            SetPointTemp = 36.5;
            _actualTemp = 0;
        }

        public void Regulate(double actualTemp)
        {
            if (actualTemp != _actualTemp)
            {
                _actualTemp = actualTemp;
                if (actualTemp < SetPointTemp)
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
}
