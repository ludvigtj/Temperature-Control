using nanoFramework.TestFramework;
using RelayControl;
using TemperatureControl.RelayControl.Interfaces;
using TemperatureControl.Tests.Unit.TestsForRelayControl.Fakes;

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
        public void ctor_ValveClosed()
        {
            Assert.IsFalse(uut.ValveOpen);
        }

        [TestMethod]
        public void OpenValve_MethodCalled_ValveOpen()
        {
            uut.OpenValve();
            Assert.IsTrue(uut.ValveOpen);
        }

        [TestMethod]
        public void OpenValve_TwoMethodsCalled_ValveOpen()
        {
            uut.CloseValve();
            uut.OpenValve();
            Assert.IsTrue(uut.ValveOpen);
        }
        [TestMethod]
        public void OpenValve_()
        {
            uut.OpenValve();
            Assert.IsTrue(uut.ValveOpen);
        }

        [TestMethod]
        public void CloseValve_MethodCalled_ValveClosed()
        {
            uut.CloseValve();
            Assert.IsFalse(uut.ValveOpen);
        }

        [TestMethod]
        public void CloseValve_MethodCalledTwice_ValveClosed()
        {
            uut.CloseValve();
            uut.CloseValve();
            Assert.IsFalse(uut.ValveOpen);
        }
    }
}
