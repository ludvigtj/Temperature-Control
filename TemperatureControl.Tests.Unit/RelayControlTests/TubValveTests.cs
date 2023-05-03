using System;
using System.Diagnostics;
using nanoFramework.TestFramework;
using RelayControl;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.RelayControlTests.Fakes;

namespace TemperatureControl.Tests.Unit.RelayControlTests
{
    [TestClass]
    public class TubValveTests
    {
        private static IValve uut;
        private static IRelayController fakerRelayController;
        [Setup]
        public void Setup()
        {
            fakerRelayController = new FakeRelayController();
            uut = new TubValve(fakerRelayController);
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

            Assert.AreSame(ex.Message, "Relay 4 on");
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

            Assert.AreSame(ex.Message, "Relay 4 off");
        }
    }
}
