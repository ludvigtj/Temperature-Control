using System;
using System.Threading;
using RelayControl.Interfaces;
using TemperatureControl.TemperatureSensor;

namespace TemperatureControl.Model
{
    public class BusinessLogic
    {
        private IRelayController _relayController;
        private ITemperatureSensor _tempSensor;
        private IPump _pump;
        private ITemperatureRegulator _tempRegulator;

        public BusinessLogic(IRelayController relayController,ITemperatureSensor tempSensor, IPump pump, ITemperatureRegulator tempRegulator)
        {
            
        }

        public void FillVessel()
        {
            //_tabValve.OpenValve();
            //_tubValve.OpenValve();
            Thread.Sleep(300000); // Fylder i 5 minutter
            //Use stopwatch

            for (int i = 0; i < 10; i++) // lukker og åbner ventil i intervaller af 1 sekund i 10 sekunder
            {
                //_tabValve.CloseValve(); - These members are not a part of the interface
                //Thread.Sleep(1000);
                //i++;
                //_tabValve.OpenValve(); 
                //Thread.Sleep(1000);
            }
            _pump.TurnOnPump();
            //_tempRegulator.Regulate(_tempSensor.ReadTemperature()); - ReadTemperature interface returns void

            Thread.Sleep(900000); // Holder ventil til brugsvand åben i 15 minutter

            //_tabValve.CloseValve();

            // IKKE GJORT ENDNU     Sluk pumpe, temperaturregulering og luk ventil til karret efter 5 timer.
        }

        public void EmptyVessel()
        {
            //_tubValve.CloseValve();
            _pump.TurnOnPump();
            //_tempRegulator.StopRegulate(); - Not in interface

            Thread.Sleep(1200000); // Skal tømme i 20 minutter. Kan dette bare løses sådan? 
            _pump.TurnOffPump();

        }

        public void RegulateTemperature(double setPointTemp)
        {
            //_tubValve.OpenValve();
            _pump.TurnOnPump();
            _tempRegulator.Regulate(setPointTemp);

            Timer timer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

            void TimerCallback(object state)
            {
                //_tubValve.CloseValve();
                _pump.TurnOffPump();
                //_tempRegulator.StopRegulate();
            }
        }
    }
}
