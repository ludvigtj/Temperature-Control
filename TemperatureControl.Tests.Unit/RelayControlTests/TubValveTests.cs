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
        private static IValve _uut;
        private static IRelayController _fakerRelayController;
        [Setup]
        public void Setup()
        {
            _fakerRelayController = new FakeRelayController();
            _uut = new TubValve(_fakerRelayController);
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

            Assert.AreSame(ex.Message, "Relay 4 on");
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

            Assert.AreSame(ex.Message, "Relay 4 off");
        }
        [TestMethod]
        public void OpenValve_MethodMultipleTimes_ExceptionThrown()
        {
            Exception ex = new Exception();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    _uut.OpenValve();
                }
                catch (Exception e)
                {
                    ex = e;
                }
            }
            Assert.AreSame(ex.Message, "Relay 3 on");
        }

        [TestMethod]
        public void CloseValve_MethodMultipleTimes_ExceptionThrown()
        {
            Exception ex = new Exception();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    _uut.CloseValve();
                }
                catch (Exception e)
                {
                    ex = e;
                }
            }
            Assert.AreSame(ex.Message, "Relay 3 off");
        }
    }
}
