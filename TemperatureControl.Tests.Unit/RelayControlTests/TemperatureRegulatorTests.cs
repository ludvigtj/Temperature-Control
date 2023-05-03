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
        private static IRelayController fakeRelay;
        private static ITemperatureRegulator uut;

        [Setup]
        public void Setup()
        {
            fakeRelay = new FakeRelayController();
            uut = new TemperatureRegulator(fakeRelay);
        }


        [TestMethod]
        public void Regulate_ActualLowerThanSetPoint_RelayOn()
        {
            uut.SetPointTemp = 38;
            Exception ex = new Exception();
            try
            {
                uut.Regulate(34);
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
            uut.SetPointTemp = 38;
            Exception ex = new Exception();
            try
            {
                uut.Regulate(39);
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
            uut.SetPointTemp = 38;
            Exception ex = new Exception();
            try
            {
                uut.Regulate(38);
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
            uut.SetPointTemp = 38;
            bool secondException = false;
            try
            {
                uut.Regulate(39);
            }
            catch (Exception e) { }
            try
            {
                uut.Regulate(39);
            }
            catch (Exception e)
            {
                secondException = true;
            }
            Assert.IsFalse(secondException);
        }

    }
}
