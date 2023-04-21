﻿using System;
using Iot.Device.Relay;
using System.Device.I2c;
using System.Globalization;
using System.Threading;
using nanoFramework.Hardware.Esp32;

namespace RelayControl
{
    public class RelayControl
    {
        // Browse our samples repository: https://github.com/nanoframework/samples
        // Check our documentation online: https://docs.nanoframework.net/
        // Join our lively Discord community: https://discord.gg/gCyBu8T

        // https://docs.nanoframework.net/devicesdetails/Relay4/README.html

        private Unit4Relay unit4Relay;
        public RelayControl()
        {
            Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);

            unit4Relay = new(new I2cDevice(new I2cConnectionSettings(1, Base4Relay.DefaultI2cAddress)));

            unit4Relay.SynchronizedMode = true;

            //// This will synchronize the led with the relay
            //unit4Relay.SynchronizedMode = true;
            
            //// Set relay 2, the led 2 should be on
            //unit4Relay.SetRelay(2, State.On);

            //// Set back the asyn modo
            ////unit4Relay.SynchronizedMode = false;

            //// Set relay 1, the led 1 should be off while the relay on
            //unit4Relay.SetRelay(1, State.On);

            //// Set led 0 to on, the relay should be off
            //unit4Relay.SetLed(0, State.On);
        }

        //Relay:
        //1: Pumpe, 2:varmelegeme, 3: ventil til brugsvand, 4: ventil til karret
        public void TurnOnRelay(byte number)
        {
            unit4Relay.SetRelay(number, State.On);
        }
        public void TurnOffRelay(byte number)
        {
            unit4Relay.SetRelay(number, State.Off);
        }

    }
}