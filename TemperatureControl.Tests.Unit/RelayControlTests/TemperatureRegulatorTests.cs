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


        #region RegulateRelayOffInTheBeginning
        [TestMethod]
        public void Regulate_RelayOffCurrentLowerThanHysteresis_RelayOn()
        {
            double[] currentTemps = new double[] { -5, -1.2, 0, 34, 37.7 };
            for (int i = 0; i < currentTemps.Length; i++)
            {
                Exception ex = new Exception();
                _uut = new TemperatureRegulator(_fakeRelay);
                _uut.CurrentTemp = currentTemps[i];
                _uut.SetPointTemp = 38;
                try
                {
                    _uut.Regulate();
                }
                catch (Exception e)
                {
                    ex = e;
                }
                Assert.AreSame(ex.Message, "Relay 2 on");
            }
        }

        [TestMethod]
        public void Regulate_RelayOffCurrentHigherThanHysteresis_NoChangeInRelay()
        {
            double[] currentTemps = new double[] { 38.3, 40, 1000 };
            for (int i = 0; i < currentTemps.Length; i++)
            {
                int state = 0;
                Exception ex = new Exception();
                _uut = new TemperatureRegulator(_fakeRelay);
                _uut.CurrentTemp = currentTemps[i];
                _uut.SetPointTemp = 38;
                try
                {
                    _uut.Regulate();
                    state = 1;
                }
                catch (Exception e)
                {
                    ex = e;
                    state = 2;
                }
                Assert.AreEqual(1, state);
            }
        }

        [TestMethod]
        public void Regulate_RelayOffCurrentWithinHysteresis_NoChangeInRelay()
        {
            double[] currentTemps = new double[] { 37.8, 37.9, 38, 38.2 };
            for (int i = 0; i < currentTemps.Length; i++)
            {
                int state = 0;
                Exception ex = new Exception();
                _uut = new TemperatureRegulator(_fakeRelay);
                _uut.CurrentTemp = currentTemps[i];
                _uut.SetPointTemp = 38;
                try
                {
                    _uut.Regulate();
                    state = 1;
                }
                catch (Exception e)
                {
                    ex = e;
                    state = 2;
                }
                Assert.AreEqual(1, state);
            }
        }
        #endregion
        public void TurnOnRelayForTest(ITemperatureRegulator uut)
        {
            Exception ex = new Exception();
            _uut = uut;
            _uut.CurrentTemp = 21;
            _uut.SetPointTemp = 38;
            try
            {
                _uut.Regulate();
            }
            catch (Exception e)
            {
                ex = e;
            }
        }

        #region RegulateRelayOnIntheBeginning

        [TestMethod]
        public void Regulate_RelayOnCurrentLowerThanHysteresis_NoChangeInRelay()
        {
            double[] currentTemps = new double[] { -5, -1.2, 0, 34, 37.7 };
            for (int i = 0; i < currentTemps.Length; i++)
            {
                int state = 0;
                _uut = new TemperatureRegulator(_fakeRelay);
                TurnOnRelayForTest(_uut);
                _uut.CurrentTemp = currentTemps[i];
                _uut.SetPointTemp = 38;
                try
                {
                    _uut.Regulate();
                    state = 1;
                }
                catch (Exception e)
                {
                    state = 2;
                }
                Assert.AreEqual(1, state);

            }

        }

        [TestMethod]
        public void Regulate_RelayOnCurrentHigherThanHysteresis_RelayOff()
        {
            double[] currentTemps = new double[] { 38.3, 40, 1000 };
            for (int i = 0; i < currentTemps.Length; i++)
            {
                Exception ex = new Exception();
                _uut = new TemperatureRegulator(_fakeRelay);
                TurnOnRelayForTest(_uut);
                _uut.CurrentTemp = currentTemps[i];
                _uut.SetPointTemp = 38;
                try
                {
                    _uut.Regulate();
                }
                catch (Exception e)
                {
                    ex = e;
                }
                Assert.AreSame(ex.Message, "Relay 2 off");
            }
        }

        [TestMethod]
        public void Regulate_RelayOnCurrentWithinHysteresis_NoChangeInRelay()
        {
            double[] currentTemps = new double[] { 37.8, 37.9, 38, 38.2 };
            for (int i = 0; i < currentTemps.Length; i++)
            {
                int state = 0;
                _uut = new TemperatureRegulator(_fakeRelay);
                TurnOnRelayForTest(_uut);
                _uut.CurrentTemp = currentTemps[i];
                _uut.SetPointTemp = 38;
                try
                {
                    _uut.Regulate();
                    state = 1;
                }
                catch (Exception e)
                {
                    state = 2;
                }
                Assert.AreEqual(1, state);
            }
        }
        #endregion

        #region RegulateCalledMoreThanOnce

        [TestMethod]
        public void Regulate_RelayOffCurrentLowerThanHysteresisCalledMoreThanOnce_RelayOn()
        {
            Exception ex = new Exception();
            int count = 0;
            int j = 0;
            _uut = new TemperatureRegulator(_fakeRelay);
            _uut.CurrentTemp = 34;
            _uut.SetPointTemp = 38;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    _uut.Regulate();
                }
                catch (Exception e)
                {
                    if (e.Message == "Relay 2 on")
                    {
                        count++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            Assert.AreEqual(1, count); //Metoden bør kun kaldes første gang
            Assert.AreEqual(0, j); //Der bør ikke være andre exceptions
        }

        [TestMethod]
        public void Regulate_RelayOffCurrentHigherThanHysteresisCalledMoreThanOnce_NoChangeInRelay()
        {
            int count = 0;
            _uut = new TemperatureRegulator(_fakeRelay);
            _uut.CurrentTemp = 40;
            _uut.SetPointTemp = 38;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    _uut.Regulate();
                }
                catch (Exception e)
                {
                    count++;
                }
            }
            Assert.AreEqual(0, count); //Der bør ikke være nogen exceptions
        }
        #endregion

        #region StopRegulate
        [TestMethod]
        public void StopRegulate_RelayOff_NoChangeInRelay()
        {
            Exception ex = new Exception();
            int state = 0;
            _uut = new TemperatureRegulator(_fakeRelay);
            try
            {
                _uut.StopRegulate();
                state = 1;
            }
            catch (Exception e)
            {
                state = 2;
                ex = e;
            }
            Assert.AreEqual(1, state);
        }
        [TestMethod]
        public void StopRegulate_RelayOn_RelayOff()
        {
            Exception ex = new Exception();
            _uut = new TemperatureRegulator(_fakeRelay);
            TurnOnRelayForTest(_uut);
            try
            {
                _uut.StopRegulate();
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.AreSame(ex.Message, "Relay 2 off");
        }
        #endregion
    }
}
