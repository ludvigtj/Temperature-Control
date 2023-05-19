using System.Device.I2c;
using System.Diagnostics;
using System.Threading;
using Iot.Device.Relay;
using nanoFramework.M5Stack;
using RelayControl;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel
{
    public class TestMethodInvoker
    {
        public int eventCounter = 0;
        private IBusinessLogic _logic;
        bool _locked = false;
        public TestMethodInvoker()
        {
            Tough.TouchEvent += Tough_TouchEvent;
            _logic = LogicFactory.GetNewLogic();
            Thread checkTempThread = new Thread(_logic.CheckTemperature);
            checkTempThread.Start();
        }

        

        private void Tough_TouchEvent(object sender, nanoFramework.Tough.TouchEventArgs e)
        {
            if (_locked) return;
            _locked = true;
            Console.Clear();
            switch (eventCounter)
            {
                case 0:
                    Console.WriteLine("Testing Use Case 1: Fyld Kar");
                    Debug.WriteLine("Testing Use Case 1: Fyld Kar");
                    _logic.SetPointTemperature = 802;
                    _logic.FillVessel();
                    break;
                case 1:
                    Console.WriteLine("Testing Use Case 1: Fyld Kar Ex. 1");
                    Debug.WriteLine("Testing Use Case 1: Fyld Kar Ex. 1");
                    _logic.SetPointTemperature = 802;
                    _logic.FillVessel();
                    Console.WriteLine("Sleeping for 3 seconds");
                    Debug.WriteLine("Sleeping for 3 seconds");
                    Thread.Sleep(3000);
                    _logic.FillVessel();
                    break;
                case 2:
                    Console.WriteLine("Testing Use Case 1: Fyld Kar Ex. 2");
                    _logic.SetPointTemperature = 798;
                    _logic.FillVessel();
                    break;
                case 3:
                    break;


            }
            eventCounter++;
            Thread.Sleep(5000);
            _locked = false;
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