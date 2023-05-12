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
        private static IRelayController _fakeRelay;
        private static IPump _uut;

        [Setup]
        public void Setup()
        {
            _fakeRelay = new FakeRelayController();
            _uut = new Pump(_fakeRelay);
        }

        [TestMethod]
        public void TurnOnPump_MethodCalled_ExceptionThrown()
        {
            Exception ex = new Exception();
            try
            {
                _uut.TurnOnPump();
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
                _uut.TurnOffPump();
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreSame(ex.Message, "Relay 1 off");
        }
    }
}
