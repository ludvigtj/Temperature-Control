using nanoFramework.UI;
using System.Threading;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.ViewModel.Interfaces;
using TemperatureSensor.Interfaces;

namespace TemperatureControl.ViewModel
{
    public class BusinessLogic : IBusinessLogic
    {
        private ITemperatureSensor _tempSensor;
        private IPump _pump;
        private ITemperatureRegulator _tempRegulator;
        private IValve _tabValve;
        private IValve _tubValve;
        public bool IsRegulating { get; set; } = false;

        #region Timers
        private Timer _fillingTimer;
        private Timer _valveTimer;
        private Timer _fillRegulateTimer;
        private Timer _emptyingTimer;
        private Timer _regulateTimer;
        #endregion

        #region CurrentTemperature
        public event PropertyChangedEventHandler CurrentTemperatureChanged;
        private double _currentTemperature;
        private double _currentTemperatureOld;
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
                    _currentTemperatureOld = _currentTemperature;
                    _currentTemperature = value;
                    _tempRegulator.CurrentTemp = _currentTemperature;
                    NotifyCurrentTemperatureChanged();
                }
            }
        }   // CurrentTemperature skal databindes med displayet.
        private void NotifyCurrentTemperatureChanged()
        {
            CurrentTemperatureChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTemperature), _currentTemperatureOld, _currentTemperature));
        }
        #endregion

        #region SetPointTemperature
        public event PropertyChangedEventHandler SetPointTemperatureChanged;
        private double _setPointTemperature;
        private double _setPointTemperatureOld;
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
                    _setPointTemperatureOld = _setPointTemperature;
                    _setPointTemperature = value;
                    _tempRegulator.SetPointTemp = _setPointTemperature;
                    NotifySetPointTemperatureChanged();
                }
            }
        }   // SetPointTemperature skal databindes med displayet.
        private void NotifySetPointTemperatureChanged()
        {
            SetPointTemperatureChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SetPointTemperature), _setPointTemperatureOld, _setPointTemperature));
        }
        #endregion


        public BusinessLogic(ITemperatureSensor tempSensor, IPump pump, ITemperatureRegulator tempRegulator, IValve tabValve, IValve tubValve)
        {
            _tempSensor = tempSensor;
            _pump = pump;
            _tempRegulator = tempRegulator;
            _tabValve = tabValve;
            _tubValve = tubValve;
        }

        public void FillVessel()
        {
            if (_fillRegulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _fillRegulateTimer.Dispose();
            }
            if (_regulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _regulateTimer.Dispose();
            }

            _tabValve.OpenValve();
            _tubValve.OpenValve();

            _fillingTimer = new Timer(FillingCallback, null, 5 * 60 * 1000, Timeout.Infinite); // Fylder i 5 minutter

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
                IsRegulating = true; // starter temperaturregulering

                _valveTimer = new Timer(TimerCallback, null, 15 * 60 * 1000, Timeout.Infinite); // Holder ventil til brugsvand åben i 15 minutter
            }

            void TimerCallback(object state)
            {
                _tabValve.CloseValve();
                _fillRegulateTimer = new Timer(FillRegulateCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite); // Regulering kører i 5 timer
                IsRegulating = true; // starter temperaturregulering
            }

            void FillRegulateCallback(object state)
            {
                _pump.TurnOffPump();
                _tubValve.CloseValve();
                _tempRegulator.StopRegulate();
                IsRegulating = false; // //Sluk pumpe, temperaturregulering og luk ventil til karret efter 5 timer.
            }
        }

        public void EmptyVessel()
        {
            if (_fillRegulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _fillRegulateTimer.Dispose();
            }
            if (_regulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _regulateTimer.Dispose();
            }

            _tubValve.CloseValve();
            _pump.TurnOnPump();
            _tempRegulator.StopRegulate();
            IsRegulating = false; // stopper temperaturreguleringen

            _emptyingTimer = new Timer(TimerCallback, null, 20 * 60 * 1000, Timeout.Infinite); // tømmer karret i 20 minutter

            void TimerCallback(object state)
            {
                _pump.TurnOffPump();
            }
        }

        public void RegulateTemperature()
        {
            if (_fillRegulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _fillRegulateTimer.Dispose();
            }
            if (_regulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _regulateTimer.Dispose();
            }
            _tubValve.OpenValve();
            _pump.TurnOnPump();
            IsRegulating = true; // starter temperaturregulering
            _regulateTimer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite); // 5 timer

            void TimerCallback(object state)
            {
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                _tempRegulator.StopRegulate();
                IsRegulating = false; // stopper temperaturreguleringen
            }
        }

        public void CheckTemperature()
        {
            while (true)
            {
                CurrentTemperature = _tempSensor.ReadTemperature();

                if (CurrentTemperature < SetPointTemperature + 2 && CurrentTemperature > SetPointTemperature - 2)
                {
                    Thread.Sleep(200);
                    if (IsRegulating)
                    {
                        _tempRegulator.Regulate();
                    }

                }
                _tabValve.CloseValve();
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                _tempRegulator.StopRegulate();
                IsRegulating = false; // stopper temperaturreguleringen
            }
        }
    }
}
