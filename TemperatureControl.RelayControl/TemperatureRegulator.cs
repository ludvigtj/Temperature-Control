using TemperatureControl.RelayControl.Interfaces;

namespace RelayControl
{
    public class TemperatureRegulator : ITemperatureRegulator
    {
        public double SetPointTemp { get; set; }

        private double _actualTemp = 0;
        private readonly RelayController _relay;

        public TemperatureRegulator(RelayController relay)
        {
            _relay = relay;
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

        public void StopRegulate()
        {
            throw new System.NotImplementedException();
        }
    }
}
