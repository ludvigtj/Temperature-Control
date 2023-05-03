﻿using System;
 using UnitsNet.Units;

 namespace TemperatureSensor
{
    public interface ITemperatureSensor
    {
        public TemperatureUnit ReadTemperature();
    }
}