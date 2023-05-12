using nanoFramework.TestFramework;
using RelayControl;
using System;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.RelayControlTests.Fakes;

namespace TemperatureControl.Tests.Unit.RelayControlTests
{
    [TestClass]
    public class TemperatureRaegulatorTests
    {
        private static IRelayController _fakeRelay;
        private static ITemperatureRegulator _uut;

        [Setup]
        public void Setup()
        {
            _fakeRelay = new FakeRelayController();
            _uut = new TemperatureRegulator(_fakeRelay);
        }


        [TestMethod]
        public void Regulate_ActualLowerThanSetPoint_RelayOn()
        {
            _uut.SetPointTemp = 38;
            Exception ex = new Exception();
            try
            {
                _uut.Regulate(34);
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.AreSame(ex.Message, "Relay 2 on");
        }

        [TestMethod]
        public void Regulate_ActualHigherThanSetPoint_RelayOff()
        {
            _uut.SetPointTemp = 38;
            Exception ex = new Exception();
            try
            {
                _uut.Regulate(39);
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.AreSame(ex.Message, "Relay 2 off");
        }
        [TestMethod]
        public void Regulate_ActualSameAsSetPoint_RelayOff()
        {
            _uut.SetPointTemp = 38;
            Exception ex = new Exception();
            try
            {
                _uut.Regulate(38);
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.AreSame(ex.Message, "Relay 2 off");
        }
        [TestMethod]
        public void Regulate_ActualSameAsPrevious_NoSecondException()
        {
            _uut.SetPointTemp = 38;
            Exception ex = new Exception();
            int state = 0;
            try
            {
                _uut.Regulate(39);
                state = 1;
            }
            catch (Exception e)
            {
                ex = e;
                state = 2;
            }

            if (ex.Message == "Relay 2 off")
            {
                try
                {
                    _uut.Regulate(39);
                    state = 3;
                }
                catch (Exception e)
                {
                    state = 4;
                }
            }
            Assert.AreEqual(3,state);
        }
    }
}
