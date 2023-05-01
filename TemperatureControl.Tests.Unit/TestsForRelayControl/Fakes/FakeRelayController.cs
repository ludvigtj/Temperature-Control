using System;
using System.Diagnostics;
using RelayControl.Interfaces;

namespace TemperatureControl.Tests.Unit.TestsForRelayControl.Fakes
{
    internal class FakeRelayController : IRelayController
    {
        public bool RelayOn1 { get; private set; } = false;
        public bool RelayOn2 { get; private set; } = false;
        public bool RelayOn3 { get; private set; } = false;
        public bool RelayOn4 { get; private set; } = false;
        public void TurnOnRelay(byte number)
        {
            switch (number)
            {
                case 1: 
                    RelayOn1 = true; 
                    break;
                case 2:
                    RelayOn2 = true;
                    break;
                case 3:
                    RelayOn3 = true;
                    break;
                case 4:
                    RelayOn4 = true;
                    break;
            }
        }

        public void TurnOffRelay(byte number)
        {
            switch (number)
            {
                case 1:
                    RelayOn1 = false;
                    break;
                case 2:
                    RelayOn2 = false;
                    break;
                case 3:
                    RelayOn3 = false;
                    break;
                case 4:
                    RelayOn4 = false;
                    break;
            }
        }

        //public void TurnOnRelay(byte number)
        //{
        //    switch (number)
        //    {
        //        case 1:
        //            Debug.WriteLine("Relay 1 on");
        //            break;
        //        case 2:
        //            Debug.WriteLine("Relay 2 on");
        //            break;
        //        case 3:
        //            Debug.WriteLine("Relay 3 on");
        //            break;
        //        case 4:
        //            Debug.WriteLine("Relay 4 on");
        //            break;
        //    }
        //}

        //public void TurnOffRelay(byte number)
        //{
        //    switch (number)
        //    {
        //        case 1:
        //            Debug.WriteLine("Relay 1 off");
        //            break;
        //        case 2:
        //            Debug.WriteLine("Relay 2 off");
        //            break;
        //        case 3:
        //            Debug.WriteLine("Relay 3 off");
        //            break;
        //        case 4:
        //            Debug.WriteLine("Relay 4 off");
        //            break;
        //    }
        //}
    }
}
