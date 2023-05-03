using System;
using System.Threading;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureSensor.Interfaces;

namespace TemperatureControl.ViewModel
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

        public void FillVessel(double setPointTemp)
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
            _tempRegulator.Regulate(setPointTemp);

            //Thread.Sleep(900000); // Holder ventil til brugsvand åben i 15 minutter

            //_tabValve.CloseValve();

            Timer timer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

            void TimerCallback(object state)
            {
                //_tabValve.CloseValve();
            }

            // ER I TVIVL OM NEDENSTÅENDE

            Timer timer2 = new Timer(TimerCallback2, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

            void TimerCallback2(object state)
            {
                _pump.TurnOffPump();
                //_tubValve.CloseValve();
                //_tempRegulator.StopRegulate(); //Sluk pumpe, temperaturregulering og luk ventil til karret efter 5 timer.
            }
        }

        public void EmptyVessel()
        {
            //_tubValve.CloseValve();
            _pump.TurnOnPump();
            //_tempRegulator.StopRegulate(); - Not in interface

            //Thread.Sleep(1200000); // Skal tømme i 20 minutter. Kan dette bare løses sådan? 
            //_pump.TurnOffPump();

            Timer timer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

            void TimerCallback(object state)
            {
                _pump.TurnOffPump();
            }

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

        public void CheckTemperature(double setPointTemp)
        {
            //while (_tempSensor.ReadTemperature() < setPointTemp + 2 || _tempSensor.ReadTemperature() > setPointTemp -2 )
            {
   
            }

            //_tabValve.CloseValve();
            //_tubValve.CloseValve();
            _pump.TurnOffPump();
            //_tempRegulator.StopRegulate();
        }
    }
}
