using System;
using System.Diagnostics;
using nanoFramework.M5Stack;
using nanoFramework.Tough;

namespace TemperatureControl.ViewModel.Abstract
{
    internal interface ITouchHandler
    {
        void TouchEventCallback(object sender, TouchEventArgs e);
    }
}
