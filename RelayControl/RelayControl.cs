using System;
using Iot.Device.Relay;
using System.Device.I2c;
using System.Threading;
using nanoFramework.Hardware.Esp32;

namespace RelayControl
{
    public class RelayControl
    {
        // Browse our samples repository: https://github.com/nanoframework/samples
        // Check our documentation online: https://docs.nanoframework.net/
        // Join our lively Discord community: https://discord.gg/gCyBu8T

        public RelayControl()
        {
            Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);
        }

        
    }
}
