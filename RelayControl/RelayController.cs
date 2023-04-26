using System;
using Iot.Device.Relay;
using System.Device.I2c;
using System.Globalization;
using System.Threading;
using nanoFramework.Hardware.Esp32;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class RelayController : IRelayController
    {
        // Browse our samples repository: https://github.com/nanoframework/samples
        // Check our documentation online: https://docs.nanoframework.net/
        // Join our lively Discord community: https://discord.gg/gCyBu8T

        // https://docs.nanoframework.net/devicesdetails/Relay4/README.html

        private readonly Unit4Relay _unit4Relay;

        public RelayController()
        {
            Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);

            _unit4Relay = new(new I2cDevice(new I2cConnectionSettings(1, Base4Relay.DefaultI2cAddress)));

            _unit4Relay.SynchronizedMode = true;
        }
        
        //1: Pumpe, 2:varmelegeme, 3: ventil til brugsvand, 4: ventil til karret
        public void TurnOnRelay(byte number)
        {
            _unit4Relay.SetRelay(number, State.On);
        }
        public void TurnOffRelay(byte number)
        {
            _unit4Relay.SetRelay(number, State.Off);
        }

    }
}
