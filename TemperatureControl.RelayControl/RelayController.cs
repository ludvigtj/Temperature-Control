using Iot.Device.Relay;
using System.Device.I2c;
using System.Globalization;
using System.Threading;
using nanoFramework.Hardware.Esp32;
using TemperatureControl.RelayControl.Interfaces;


namespace RelayControl
{
    public class RelayController : IRelayController
    {
        // Browse our samples repository: https://github.com/nanoframework/samples
        // Check our documentation online: https://docs.nanoframework.net/
        // Join our lively Discord community: https://discord.gg/gCyBu8T

        // https://docs.nanoframework.net/devicesdetails/Relay4/README.html

        private readonly Unit4Relay _unit4Relay;
        public RelayController(I2cDevice i2cDevice)
        {
            //I2cDevice i2cDevice = Tough.GetI2cDevice(Base4Relay.DefaultI2cAddress);

            Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);

            _unit4Relay = new(i2cDevice);

            _unit4Relay.SynchronizedMode = true;
            _unit4Relay.SetAllLedAndRelay(State.Off);
        }

        //0: Pumpe, 1:varmelegeme, 2: ventil til brugsvand, 3: ventil til karret
        public void TurnOnRelay(byte number)
        {
            _unit4Relay.SetRelay(number, State.Off); //fra praktisk erfaring viser det sig at State.Off tænder relayet
        }
        public void TurnOffRelay(byte number)
        {
            _unit4Relay.SetRelay(number, State.On); //fra praktisk erfaring viser det sig at State.On slukker relayet
        }

    }
}
