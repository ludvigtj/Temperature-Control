using nanoFramework.M5Stack;
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
            if (ValidateTimer(_fillRegulateTimer))
            {
                _fillRegulateTimer.Dispose();
                _tabValve.CloseValve();
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                Console.WriteLine("Fyldtimer stoppet, ventil til brugsvand og kar lukket. Pumpe slukket");
                IsRegulating = false;
                Console.WriteLine("Fyld-funktion er inaktiv");
            }
            if (ValidateTimer(_regulateTimer))
            {
                _regulateTimer.Dispose();
            }

            _tabValve.OpenValve();
            _tubValve.OpenValve();

            _fillingTimer = new Timer(FillingCallback, null, 5 * 60 * 1000, Timeout.Infinite); // Fylder i 5 minutter
            Console.WriteLine("Ventil til brugsvand og karret åben");
            Console.WriteLine("Fyld-funktion aktiv");

            void FillingCallback(object state)
            {
                int close = 0;
                int open = 0;
                for (int i = 0; i < 10; i++) // lukker og åbner ventil i intervaller af 1 sekund i 10 sekunder
                {
                    _tabValve.CloseValve();
                    close++;
                    Thread.Sleep(1000);
                    i++;
                    _tabValve.OpenValve();
                    open++;
                    Thread.Sleep(1000);
                }
                Console.WriteLine($"Lukket {close} gange og åbent {open} gange");
                _pump.TurnOnPump();
                Console.WriteLine("Ventil til brugsvand åben og pumpe tændt");
                IsRegulating = true; // starter temperaturregulering

                _valveTimer = new Timer(TimerCallback, null, 15 * 60 * 1000, Timeout.Infinite); // Holder ventil til brugsvand åben i 15 minutter
            }

            void TimerCallback(object state)
            {
                _tabValve.CloseValve();
                _fillRegulateTimer = new Timer(FillRegulateCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite); // Regulering kører i 5 timer
                IsRegulating = true; // starter temperaturregulering
                Console.WriteLine("Ventil til brugsvand lukket");
            }

            void FillRegulateCallback(object state)
            {
                _pump.TurnOffPump();
                _tubValve.CloseValve();
                _tempRegulator.StopRegulate();
                IsRegulating = false; // //Sluk pumpe, temperaturregulering og luk ventil til karret efter 5 timer.
                Console.WriteLine("Pumpe og ventil lukket. Temperaturregulering slukket");
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
            Console.WriteLine("Ventil til karret lukket. Pumpe tændt. Temperaturregulering slukket");


            _emptyingTimer = new Timer(TimerCallback, null, 20 * 60 * 1000, Timeout.Infinite); // tømmer karret i 20 minutter

            void TimerCallback(object state)
            {
                _pump.TurnOffPump();
                Console.WriteLine("Pumpe slukket.");
            }
        }

        public void RegulateTemperature()
        {
            if (_fillRegulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _fillRegulateTimer.Dispose();
                Console.WriteLine("Ventil til kar lukket. Pumpe slukket.");
                IsRegulating = false;
            }
            if (_regulateTimer.Change(Timeout.Infinite, Timeout.Infinite) == true)
            {
                _regulateTimer.Dispose();
                Console.WriteLine("Ventil til kar lukket. Pumpe slukket.");
                IsRegulating = false;
            }
            _tubValve.OpenValve();
            _pump.TurnOnPump();
            IsRegulating = true; // starter temperaturregulering
            _regulateTimer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite); // 5 timer
            Console.WriteLine("Ventil til karret åben og pumpe tændt");


            void TimerCallback(object state)
            {
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                _tempRegulator.StopRegulate();
                IsRegulating = false; // stopper temperaturreguleringen
                Console.WriteLine("Ventil til karret lukket. Pumpe slukket");
            }
        }

        public void CheckTemperature()
        {
            while (true)
            {
                Thread.Sleep(200);
                CurrentTemperature = _tempSensor.ReadTemperature();
                if (CurrentTemperature < SetPointTemperature + 2 && CurrentTemperature > SetPointTemperature - 2)
                {
                    
                    if (IsRegulating)
                    {
                        _tempRegulator.Regulate();
                        
                    }
                    continue;
                }
                _tabValve.CloseValve();
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                _tempRegulator.StopRegulate();
                IsRegulating = false; // stopper temperaturreguleringen
                Console.WriteLine("Ventil til brugsvand og karret lukket. Pumpe slukket.");
            }
        }

        private bool ValidateTimer(Timer timer)
        {
            if (timer == null)
            {
                return false;
            }
            return timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
