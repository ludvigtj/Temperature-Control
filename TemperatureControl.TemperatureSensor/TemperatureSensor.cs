using Iot.Device.Max31865;
using nanoFramework.Hardware.Esp32;
using System;
using System.Device.Spi;
using System.Threading;
using TemperatureSensor;
using TemperatureSensor.Interfaces;
using UnitsNet;


namespace TemperatureControl.TemperatureSensor
{
    public class TemperatureSensor : ITemperatureSensor
    {
        SpiConnectionSettings _settings;
        double temperature;

        public TemperatureSensor()
        {
            Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
            Configuration.SetPinFunction(38, DeviceFunction.SPI1_MISO);
            Configuration.SetPinFunction(18, DeviceFunction.SPI1_CLOCK);
            // GPIO PINS for ovenstående setup fundet på: https://docs.m5stack.com/en/core/tough

            _settings = new(1, 27)  // busid = 1, da SPI port på M5 er connected med VSPI hvilket har busid 1
                                    // ChipselectLine (CS) = 27, da den skal sidde på GPIO27 på M5.
                                    // GPIO27 er ikke en CS, så derfor laver vi den softwaremæssigt i klassen GPIOCSPin. 
            {
                ClockFrequency = 1000000, // Start med 1-2 MHz, hvis det ikke er godt nok set da ClockFrequency = Max31865.SpiClockFrequency
                Mode = Max31865.SpiMode3,  // SpiMode3 skulle gerne være kombatibelt mellem MAX31865 og M5Stack Tough
                DataFlow = Max31865.SpiDataFlow // Er rigtig, da M5Stack er master og MAX31865 er slave
            };
        }

        public double ReadTemperature()
        {
            using SpiDevice device = SpiDevice.Create(_settings);
            Thread.Sleep(200);
            //fire ledninger                                                                                                           // I tvivl om denne, men kan finde at reference ohm er 430 på PT100
            //using Max31865 sensor = new(device, PlatinumResistanceThermometerType.Pt100, ResistanceTemperatureDetectorWires.FourWire, ElectricResistance.FromOhms(430));
            //to ledninger
            using Max31865 sensor = new(device, PlatinumResistanceThermometerType.Pt100, ResistanceTemperatureDetectorWires.TwoWire, ElectricResistance.FromOhms(430));
            
            temperature = sensor.Temperature.DegreesCelsius;
            
            Console.WriteLine($"Temperature: {temperature} ℃");

            return temperature;
        }
    }
}
