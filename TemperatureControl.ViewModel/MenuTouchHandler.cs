using System;
using System.Diagnostics;
using System.Text;
using nanoFramework.M5Stack;
using nanoFramework.UI.Input;
using nanoFramework.Presentation;
using TemperatureControl.ViewModel.Abstract;
using TouchEventArgs = nanoFramework.Tough.TouchEventArgs;
using Interfaces;

namespace TemperatureControl.ViewModel
{
    internal class MenuTouchHandler: ITouchHandler
    {
        private GuiElementBase[] _buttons; //maybe rename type to buttons TBD
        public MenuTouchHandler(GuiElementBase[] buttons)
        {
            Tough.TouchEvent += TouchEventCallback;
            _buttons = buttons;
        }
        public void TouchEventCallback(object sender, TouchEventArgs e)
        {
#region DEBUG
            const string StrXY1 = "TOUCHED at X= ";
            const string StrXY2 = ",Y= ";

            //Console.CursorLeft = 0;
            //Console.CursorTop = 0;

            Debug.WriteLine(StrXY1 + e.X + StrXY2 + e.Y);
#endregion
            
        }
    }
}
