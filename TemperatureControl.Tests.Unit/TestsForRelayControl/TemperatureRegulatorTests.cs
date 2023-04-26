using nanoFramework.TestFramework;
using RelayControl;

namespace TemperatureControl.Tests.Unit.RelayControl
{
    [TestClass]
    public class TemperatureRaegulatorTests
    {
        private TemperatureRegulator _uutTemperatureRegulator;
        private readonly global::RelayControl.RelayControl _relay;
        [Setup]
        public void Setup()
        {
            _uutTemperatureRegulator = new TemperatureRegulator(_relay);
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
