using nanoFramework.TestFramework;
using RelayControl;
using System;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.RelayControlTests.Fakes;

namespace TemperatureControl.Tests.Unit.RelayControlTests
{
    [TestClass]
    public class TapValveTests
    {
        private static IValve _uut;
        private static IRelayController _fakerRelayController;
        [Setup]
        public void Setup()
        {
            _fakerRelayController = new FakeRelayController();
            _uut = new TapValve(_fakerRelayController);
        }

        [TestMethod]
        public void OpenValve_MethodCalled_ExceptionThrown()
        {
            Exception ex = new Exception();
            try
            {
                _uut.OpenValve();
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreSame(ex.Message, "Relay 3 on");
        }

        [TestMethod]
        public void CloseValve_MethodCalled_ExceptionThrown()
        {
            Exception ex = new Exception();
            try
            {
                _uut.CloseValve();
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreSame(ex.Message, "Relay 3 off");
        }
    }
}
