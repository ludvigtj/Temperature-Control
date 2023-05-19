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
            _logic = LogicFactory.GetNewLogic();
            _logic.SetPointTemperature = 802;
            Thread checkTempThread = new Thread(_logic.CheckTemperature);
            checkTempThread.Start();
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

        private void Invoke()
        {
            _logic = LogicFactory.GetNewLogic();
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
                    Console.WriteLine("Sleeping for 3 seconds");
                    Debug.WriteLine("Sleeping for 3 seconds");
                    Thread.Sleep(3000);
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
                    Console.WriteLine("-.5C to SetPoint. New is "+_logic.SetPointTemperature);
                    _logic.SetPointTemperature -= 0.5;
                    break;
                case 5:
                    Console.WriteLine("Testing Use Case 2: Reguler temperatur Ex. 2");
                    Debug.WriteLine("Testing Use Case 2: Reguler temperatur Ex. 2");

                    break;
                case 6:
                    Console.WriteLine("Testing Use Case 3: Tøm kar");
                    Debug.WriteLine("Testing Use Case 3: Tøm kar");
                    break;
                case 7:
                    Console.WriteLine("Testing Use Case 3: Tøm kar Ex. 1");
                    Debug.WriteLine("Testing Use Case 3: Tøm kar Ex. 1");

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