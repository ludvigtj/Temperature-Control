using System;
using System.Threading;
using Iot.Device.Max31865;
using System.Device.Spi;
using System.Device.Gpio;
using UnitsNet;
using nanoFramework.Hardware.Esp32;

namespace TemperatureControl.TemperatureSensor
{
    

    public class TemperatureSensor : ITemperatureSensor
    {
        SpiConnectionSettings _settings;

        public TemperatureSensor()
        {
            Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
            Configuration.SetPinFunction(38, DeviceFunction.SPI1_MISO);
            Configuration.SetPinFunction(0, DeviceFunction.SPI1_CLOCK);
            // GPIO PINS for ovenstående setup fundet på: https://docs.m5stack.com/en/core/tough

            _settings = new(1, 5)  // busid = 1, da SPI port på M5 er connected med VSPI hvilket har busid 1
                                   // ChipselectLine (CS) = 5, da den skal sidde på GPIO5 på M5 
            {
                ClockFrequency = 1000000, // Start med 1-2 MHz, hvis det ikke er godt nok set da ClockFrequency = Max31865.SpiClockFrequency
                Mode = Max31865.SpiMode3,  // SpiMode3 skulle gerne være kombatibelt mellem MAX31865 og M5Stack Tough
                DataFlow = Max31865.SpiDataFlow // Er rigtig, da M5Stack er master og MAX31865 er slave
            };
        }

        public void ReadTemperature()
        {
            using SpiDevice device = SpiDevice.Create(_settings);                         //fire ledninger                                                                                                           // I tvivl om denne, men kan finde at reference ohm er 430 på PT100
                                                                                          //using Max31865 sensor = new(device, PlatinumResistanceThermometerType.Pt100, ResistanceTemperatureDetectorWires.FourWire, ElectricResistance.FromOhms(430));

            //to ledninger
            using Max31865 sensor = new(device, PlatinumResistanceThermometerType.Pt100, ResistanceTemperatureDetectorWires.TwoWire, ElectricResistance.FromOhms(430));


            while (true)
            {
                Console.WriteLine($"Temperature: {sensor.Temperature.DegreesCelsius} ℃");

                // wait for 2000ms
                Thread.Sleep(2000);
            }
        }
    }
}
