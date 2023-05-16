using nanoFramework.TestFramework;
using RelayControl;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.TestsForRelayControl.Fakes;

namespace TemperatureControl.Tests.Unit.RelayControlTests
{
    [TestClass]
    public class PumpTests
    {
        private static IRelayController fakeRelay;
        private static IPump uut;

        [Setup]
        public void Setup()
        {
            fakeRelay = new FakeRelayController();
            uut = new Pump(fakeRelay);

        }
        [TestMethod]
        public void ctor_PumpOff()
        {
            Assert.IsFalse(uut.PumpOn);
        }

        [TestMethod]
        public void TurnOnPump_MethodCalled_PumpOn()
        {
            uut.TurnOnPump();
            Assert.IsTrue(uut.PumpOn);
        }

        [TestMethod]
        public void TurnOnPump_TwoMethodsCalled_PumpOn()
        {
            uut.TurnOffPump();
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
        public void TurnOffPump_MethodCalledTwice_PumpOff()
        {
            uut.TurnOffPump();
            uut.TurnOffPump();
            Assert.IsFalse(uut.PumpOn);
        }
    }
}
