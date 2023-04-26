using nanoFramework.TestFramework;
using RelayControl;
using NSubstitube;

namespace TemperatureControl.Tests.Unit.RelayControl
{
    [TestClass]
    public class TemperatureRaegulatorTests
    {
        [TestMethod]
        public void Regulate_TurnsOnRelay_WhenActualTempIsBelowSetPointTemp()
        {
            // Arrange
            var relayMock = Substitube.For<RelayController>();
            var tempRegulator = new TemperatureRegulator(relayMock);

            // Act
            tempRegulator.SetPointTemp = 37;
            tempRegulator.Regulate(34);

            // Assert
            relayMock.Received().TurnOnRelay(2);

        }

        
    }
}
