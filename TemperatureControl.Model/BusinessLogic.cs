using System;
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

        public void FillVessel(double setPointTemp)
        {
            _tabValve.OpenValve();
            _tubValve.OpenValve();
            Thread.Sleep(300000); // Fylder i 5 minutter
            //Brug stopwatch class

            for (int i = 0; i < 10; i++) // lukker og åbner ventil i intervaller af 1 sekund i 10 sekunder
            {
                _tabValve.CloseValve();
                Thread.Sleep(1000);
                i++;
                _tabValve.OpenValve();
                Thread.Sleep(1000);
            }
            _pump.TurnOnPump();
            _tempRegulator.Regulate(setPointTemp);

            //Thread.Sleep(900000); // Holder ventil til brugsvand åben i 15 minutter

            //_tabValve.CloseValve();

            Timer timer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

            void TimerCallback(object state)
            {
                _tabValve.CloseValve();
            }

            // ER I TVIVL OM NEDENSTÅENDE

            Timer timer2 = new Timer(TimerCallback2, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

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
            _tubValve.OpenValve();
            _pump.TurnOnPump();
            _tempRegulator.Regulate(setPointTemp);

            Timer timer = new Timer(TimerCallback, null, 5 * 60 * 60 * 1000, Timeout.Infinite);

            void TimerCallback(object state)
            {
                _tubValve.CloseValve();
                _pump.TurnOffPump();
                _tempRegulator.StopRegulate();
            }
        }

        public void CheckTemperature(double setPointTemp)
        {
            while (_tempSensor.ReadTemperature() < setPointTemp + 2 || _tempSensor.ReadTemperature() > setPointTemp -2 )
            {
   
            }

            _tabValve.CloseValve();
            _tubValve.CloseValve();
            _pump.TurnOffPump();
            _tempRegulator.StopRegulate();
        }
    }
}
