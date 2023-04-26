using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TemperatureControl.Model
{
    public class BusinessLogic
    {
        private RelayController _relayController;
        private TemperatureSensor _tempSensor;
        private TubValve _tubValve;
        private TabValve _tabValve;
        private Pump _pump;
        private TemperatureRegulator _tempRegulator;

        public BusinessLogic()
        {
            _relayController = new RelayController();
            _tempSensor = new TemperatureSensor();
            _tubValve = new TubValve();
            _tabValve = new TabValve();
            _pump = new Pump();
            _tempRegulator = new TemperatureRegulator();
        }

        public void FillVessel()
        {
            _tabValve.OpenValve();
            _tubValve.OpenValve();
            Thread.Sleep(300000); // Fylder i 5 minutter

            for (int i = 0; i < 10; i++) // lukker og åbner ventil i intervaller af 1 sekund i 10 sekunder
            {
                _tabValve.CloseValve();
                Thread.Sleep(1000);
                i++;
                _tabValve.OpenValve();
                Thread.Sleep(1000);
            }
            _pump.TurnOnPump();
            _tempRegulator.Regulate(_tempSensor.ReadTemperature());

            Thread.Sleep(900000);

            _tabValve.CloseValve();

            // Sluk pumpe, temperaturregulering og luk ventil til karret efter 5 timer.
        }

        public void EmptyVessel()
        {
            _tubValve.CloseValve();
            _pump.TurnOnPump();
            _tempRegulator.StopRegulate();

            Thread.Sleep(1200000); // Skal tømme i 20 minutter. Kan dette bare løses sådan? 
            _pump.TurnOffPump();

        }
    }
}
