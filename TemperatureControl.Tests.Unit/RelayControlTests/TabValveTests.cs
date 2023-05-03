using nanoFramework.TestFramework;
using RelayControl;
using System;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.RelayControlTests.Fakes;

namespace TemperatureControl.Tests.Unit.RelayControlTests
{
    [TestClass]
    public class TabValveTests
    {
        private static IValve uut;
        private static IRelayController fakerRelayController;
        [Setup]
        public void Setup()
        {
            fakerRelayController = new FakeRelayController();
            uut = new TabValve(fakerRelayController);
        }

        [TestMethod]
        public void OpenValve_MethodCalled_ExceptionThrown()
        {
            Exception ex = new Exception();
            try
            {
                uut.OpenValve();
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
                uut.CloseValve();
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreSame(ex.Message, "Relay 3 off");
        }
    }
}
