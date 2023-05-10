using nanoFramework.UI;
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
        private IValve _tabValve;
        private IValve _tubValve;

        public event PropertyChangedEventHandler PropertyChanged;
        private double _currentTemperature;
        public double CurrentTemperature
        {
            get
            {
                return _currentTemperature;
            }
            set
            {
                if (value != _currentTemperature)
                {
                    _currentTemperature = value;
                    NotifyCurrentTemperatureChanged();
                }
            }
        }   // CurrentTemperature skal databindes med displayet.
        private void NotifyCurrentTemperatureChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTemperature), CurrentTemperature, _currentTemperature));
        }

        private double _setPointTemperature;  
        public double SetPointTemperature
        {
            get
            {
                return _setPointTemperature;
            }
            set
            {
                if (value != _setPointTemperature)
                {
                    _setPointTemperature = value;
                    NotifySetPointTemperatureChanged();
                }
            }
        }   // SetPointTemperature skal databindes med displayet.
        private void NotifySetPointTemperatureChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SetPointTemperature), SetPointTemperature, _setPointTemperature));
        }



        public BusinessLogic(IRelayController relayController,ITemperatureSensor tempSensor, IPump pump, ITemperatureRegulator tempRegulator, IValve tabValve, IValve tubValve)
        {
            _relayController = relayController;
            _tempSensor = tempSensor;
            _pump = pump;
            _tempRegulator = tempRegulator;
            _tabValve = tabValve;
            _tubValve = tubValve;
        }

        public void FillVessel()
        {
            _tabValve.OpenValve();
            _tubValve.OpenValve();


            Timer fillingTimer = new Timer(FillingCallback, null, 5 * 60 * 1000, Timeout.Infinite); // Fylder i 5 minutter

            void FillingCallback(object state)
            {
                for (int i = 0; i < 10; i++) // lukker og åbner ventil i intervaller af 1 sekund i 10 sekunder
                {
                    _tabValve.CloseValve();
                    Thread.Sleep(1000);
                    i++;
                    _tabValve.OpenValve();
                    Thread.Sleep(1000);
                }
                _pump.TurnOnPump();
                _tempRegulator.Regulate(SetPointTemperature);

                Timer valveTimer = new Timer(TimerCallback, null, 15 * 60 * 1000, Timeout.Infinite); // 15 minutter
                // Holder ventil til brugsvand åben i 15 minutter
            }

            void TimerCallback(object state)
            {
                _tabValve.CloseValve();
                Timer timer2 = new Timer(TimerCallback2, null, 5 * 60 * 60 * 1000, Timeout.Infinite); // 5 timer
            }

            void TimerCallback2(object state)
            {
                _pump.TurnOffPump();
                _tubValve.CloseValve();
                _tempRegulator.StopRegulate(); //Sluk pumpe, temperaturregulering og luk ventil til karret efter 5 timer.
            }
        }

        public void EmptyVessel()
        {
            _tubValve.CloseValve();
            _pump.TurnOnPump();
            _tempRegulator.StopRegulate();

            Timer timer = new Timer(TimerCallback, null, 20 * 60 * 1000, Timeout.Infinite); // 20 minutter
            // Skal tømme i 20 minutter.
            void TimerCallback(object state)
            {
                _pump.TurnOffPump();
            }
        }

        public void RegulateTemperature()
        {
            _tubValve.OpenValve();
            _pump.TurnOnPump();
            _tempRegulator.Regulate(SetPointTemperature);

            Timer timer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite); // 5 timer

            void TimerCallback(object state)
            {
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                _tempRegulator.StopRegulate();
            }
        }

        public void CheckTemperature()
        {
            while (_tempSensor.ReadTemperature() < SetPointTemperature + 2 || _tempSensor.ReadTemperature() > SetPointTemperature -2 )
            {
                CurrentTemperature = _tempSensor.ReadTemperature();
                Thread.Sleep(2000);
            }

            _tabValve.CloseValve();
            _tubValve.CloseValve();
            _pump.TurnOffPump();
            _tempRegulator.StopRegulate();
        }
    }
}
