using System;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;
using Iot.Device.Relay;
using nanoFramework.M5Stack;
using nanoFramework.Tough;
using nanoFramework.UI;
using RelayControl;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.ViewModel.Interfaces;
using Console = nanoFramework.M5Stack.Console;

namespace TemperatureControl.ViewModel
{
    public class TestMethodInvoker
    {
        public int eventCounter = 0;
        private IBusinessLogic _logic;
        bool _locked = false;
        private DateTime firstTouch;
        public TestMethodInvoker()
        {
            firstTouch = DateTime.MinValue;
            Tough.TouchEvent += Tough_TouchEvent;
            _logic.SetPointTemperature = 802;
        }


        private void Tough_TouchEvent(object sender, nanoFramework.Tough.TouchEventArgs e)
        {
            Debug.WriteLine("Recieved touch: " + e.TimeStamp.Second + ":" + e.TimeStamp.Millisecond);
            Debug.WriteLine(_locked.ToString());
            if (!_locked)
            {
                Debug.WriteLine("Entered lock");
                _locked = true;
                Thread callback = new Thread(() =>
                {
                    Debug.WriteLine("Callback in 1 sec");
                    Thread.Sleep(1000);
                    Debug.WriteLine("Now invoking");
                    Invoke();
                    _locked = false;
                });
                callback.Start();
            }
            
        }

        private void Expected()
        {
            Debug.WriteLine("Forventet resultat: Ventil til brugsvand åbner, ventil til karret åbner og display viser fyld-funktion er aktiv");
            Debug.WriteLine("Forventet resultat +5min: Ventil til brugsvand åbnes/lukkes hvert sekund i 10 sekunder");
            Debug.WriteLine("Forventet resultat +10 sec: Ventil til brugsvand er åben, ”pumpe aktiv”-LED er tændt og ”temperaturregulering aktiv”-LED tændt");
            Debug.WriteLine("Forventet resultat +15min: Ventil til brugsvand lukkes og display viser fyld-funktion er inaktiv og reguler-funktion er aktiv");
            Debug.WriteLine("Forventet resultat +5t: Ventil til brugsvand åbner, ventil til karret åbner og display viser fyld-funktion er aktiv");
            Debug.WriteLine("Forventet resultat step 1: Ventil til brugsvand åbner, ventil til karret åbner og display viser fyld-funktion er aktiv");
            Debug.WriteLine("Forventet resultat step 2: Ventilen til brugsvand ukker, ventil til karret lukker, ”pumpe aktiv”-LED er slukket, ”temperaturregulering aktiv”-LED er slukket og display viser fyldfunktioner inaktiv");
        }
        private void Invoke()
        {
            //Debug.WriteLine("Forventet resultat");
            _logic = LogicFactory.GetNewLogic();
            Thread checkTempThread = new Thread(_logic.CheckTemperature);
            checkTempThread.Start();
            _logic.SetPointTemperature = 802;
            Console.Clear();
            switch (eventCounter)
            {
                case 0:
                    Console.WriteLine("Testing Use Case 1: Fyld Kar");
                    Debug.WriteLine("Testing Use Case 1: Fyld Kar");
                    _logic.FillVessel();
                    break;
                case 1:
                    Console.WriteLine("Testing Use Case 1: Fyld Kar Ex. 1");
                    Debug.WriteLine("Testing Use Case 1: Fyld Kar Ex. 1");
                    _logic.FillVessel();
                    Thread.Sleep(1000);
                    Console.WriteLine("Now calling FillVessel again");
                    Debug.WriteLine("Now calling FillVessel again");
                    _logic.FillVessel();
                    break;
                case 2:
                    Console.WriteLine("Testing Use Case 1: Fyld Kar Ex. 2");
                    Debug.WriteLine("Testing Use Case 1: Fyld Kar Ex. 2");
                    _logic.SetPointTemperature = 798;
                    _logic.FillVessel();
                    break;
                case 3:
                    Console.WriteLine("Testing Use Case 2: Reguler temperatur");
                    Debug.WriteLine("Testing Use Case 2: Reguler temperatur");
                    _logic.RegulateTemperature();
                    break;
                case 4:
                    Console.WriteLine("Testing Use Case 2: Reguler temperatur Ex. 1");
                    Debug.WriteLine("Testing Use Case 2: Reguler temperatur Ex. 1");
                    _logic.RegulateTemperature();
                    _logic.SetPointTemperature -= 0.5;
                    Console.WriteLine("-.5C to SetPoint. New is " + _logic.SetPointTemperature+". Was: "+(_logic.SetPointTemperature -0.5));
                    Debug.WriteLine("-.5C to SetPoint. New is " + _logic.SetPointTemperature + ". Was: " + (_logic.SetPointTemperature - 0.5));
                    break;
                case 5:
                    Console.WriteLine("Testing Use Case 2: Reguler temperatur Ex. 2");
                    Debug.WriteLine("Testing Use Case 2: Reguler temperatur Ex. 2");
                    _logic.RegulateTemperature();
                    Thread.Sleep(1000);
                    Debug.WriteLine("Pressing button again");
                    _logic.RegulateTemperature();
                    break;
                case 6:
                    Console.WriteLine("Testing Use Case 3: Tøm kar");
                    Debug.WriteLine("Testing Use Case 3: Tøm kar");
                    _logic.EmptyVessel();
                    break;
                case 7:
                    Console.WriteLine("Testing Use Case 3: Tøm kar Ex. 1");
                    Debug.WriteLine("Testing Use Case 3: Tøm kar Ex. 1");
                    _logic.EmptyVessel();
                    Thread.Sleep(1000);
                    Debug.WriteLine("Pressing button again");
                    _logic.EmptyVessel();
                    break;


            }
            eventCounter++;
        }
    }


    internal static class LogicFactory
    {
        private static I2cDevice i2cDevice = Tough.GetI2cDevice(Base4Relay.DefaultI2cAddress);
        public static IBusinessLogic GetNewLogic()
        {
            IRelayController controller = new RelayController(i2cDevice);
            return  new BusinessLogic(
                new TemperatureSensor.TemperatureSensor(),
                new Pump(controller),
                new TemperatureRegulator(controller),
                new TapValve(controller),
                new TubValve(controller)
            );
        }
    }
}