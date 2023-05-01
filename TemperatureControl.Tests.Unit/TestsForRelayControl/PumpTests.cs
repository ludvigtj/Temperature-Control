using nanoFramework.TestFramework;
using RelayControl;
using RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.TestsForRelayControl.Fakes;

namespace TemperatureControl.Tests.Unit.TestsForRelayControl
{
    [TestClass]
    public class PumpTests
    {
        private IRelayController fakeRelay;
        private IPump uut;

        [Setup]
        public void Setup()
        {
            fakeRelay = new FakeRelayController();
            uut = new Pump(fakeRelay);
            
        }
        [TestMethod]
        public void NoMethodsCalled_PumpOff()
        {
            bool pumpOn = uut.PumpOn;//der er her det går galt 
            Assert.IsFalse(pumpOn);
        }

        [TestMethod]
        public void TurnOnPump_MethodCalled_PumpOn()
        {
            uut.TurnOnPump();
            Assert.IsTrue(uut.PumpOn);
        }

        [TestMethod]
        public void TurnOffPump_MethodCalled_PumpOff()
        {
            uut.TurnOffPump();
            Assert.IsFalse(uut.PumpOn);
        }
        [TestMethod]
        public void TurnOnPump_TwoMethodsCalled_PumpOn()
        {
            uut.TurnOffPump();
            uut.TurnOnPump();
            Assert.IsTrue(uut.PumpOn);
        }
    }
}
