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
