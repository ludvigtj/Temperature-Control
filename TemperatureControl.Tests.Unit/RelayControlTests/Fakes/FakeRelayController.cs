using System;
using System.Diagnostics;
using TemperatureControl.RelayControl.Interfaces;

namespace TemperatureControl.Tests.Unit.RelayControlTests.Fakes
{
    internal class FakeRelayController : IRelayController
    {
        public void TurnOnRelay(byte number)
        {
            switch (number)
            {
                case 1:
                    throw new Exception("Relay 1 on");
                    break;
                case 2:
                    throw new Exception("Relay 2 on");
                    break;
                case 3:
                    throw new Exception("Relay 3 on");
                    break;
                case 4:
                    throw new Exception("Relay 4 on");
                    break;
                default:
                    throw new Exception("Default exception");
                    break;
            }
        }

        public void TurnOffRelay(byte number)
        {
            switch (number)
            {
                case 1:
                    throw new Exception("Relay 1 off");
                    break;
                case 2:
                    throw new Exception("Relay 2 off");
                    break;
                case 3:
                    throw new Exception("Relay 3 off");
                    break;
                case 4:
                    throw new Exception("Relay 4 off");
                    break;
                default:
                    throw new Exception("Default exception");
                    break;
            }
        }
    }
}
