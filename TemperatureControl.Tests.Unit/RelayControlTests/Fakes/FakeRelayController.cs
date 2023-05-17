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
                case 2:
                    throw new Exception("Relay 2 on");
                case 3:
                    throw new Exception("Relay 3 on");
                case 4:
                    throw new Exception("Relay 4 on");
                default:
                    throw new Exception("Default exception");
            }
        }

        public void TurnOffRelay(byte number)
        {
            switch (number)
            {
                case 1:
                    throw new Exception("Relay 1 off");
                case 2:
                    throw new Exception("Relay 2 off");
                case 3:
                    throw new Exception("Relay 3 off");
                case 4:
                    throw new Exception("Relay 4 off");
                default:
                    throw new Exception("Default exception");
            }
        }
    }
}
