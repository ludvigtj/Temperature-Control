using System;
using System.Diagnostics;
using nanoFramework.M5Stack;
using nanoFramework.Tough;

namespace Interfaces
{
    internal interface ITouchHandler
    {
        void TouchEventCallback(object sender, TouchEventArgs e);
    }
}
