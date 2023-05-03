using System;
using System.Diagnostics;
using nanoFramework.TestFramework;
using RelayControl;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.RelayControlTests.Fakes;

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
        public void TurnOnPump_MethodCalled_ExceptionThrown()
        {
            Exception ex = new Exception();
            try
            {
                uut.TurnOnPump();
            }
            catch(Exception e)
            {
                ex = e;
            }

            Assert.AreSame(ex.Message, "Relay 1 on");
        }

        [TestMethod]
        public void TurnOffPump_MethodCalled_ExceptionThrown()
        {
            Exception ex = new Exception();
            try
            {
                uut.TurnOffPump();
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreSame(ex.Message, "Relay 1 off");
        }
    }
}
