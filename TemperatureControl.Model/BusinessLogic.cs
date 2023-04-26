using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureControl.Model
{
    public class BusinessLogic
    {
        private RelayController _relayController;
        private TemperatureSensor _tempSensor;
        public BusinessLogic()
        {
            _relayController = new RelayController();
            _tempSensor = new TemperatureSensor();
        }

    }
}
