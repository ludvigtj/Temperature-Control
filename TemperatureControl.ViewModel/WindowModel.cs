using nanoFramework.M5Stack;
using nanoFramework.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Threading;
using nanoFramework.Tough;
using TemperatureControl.View.Elements;
using TemperatureControl.ViewModel.Interfaces;
using TemperatureControl.ViewModel.Windows;
using System.Diagnostics;
using nanoFramework.Presentation;
using Iot.Device.Axp192;
using TemperatureControl.RelayControl.Interfaces;

namespace TemperatureControl.ViewModel
{
    public enum States
    {
        STANDBY = 0, ALARM = 1, FILLING = 2, REGULATING = 3, EMPTYING = 4
    }
    public class WindowModel : IViewModel
    {
        private BusinessLogic _logic;
        private States _state
        {
            get => _state;
            set
            {
                switch (value)
                {
                    case States.STANDBY:
                        _state = value;
                        foreach (TouchButton tb in standbySubscribe)
                        {
                            tb.State = States.STANDBY;
                        }
                        break;
                    case States.ALARM:
                        _state = value;
                        foreach (TouchButton tb in alarmSubscribe)
                        {
                            tb.State = States.ALARM;
                        }
                        break;
                    case States.FILLING:
                        _state = value;
                        foreach (TouchButton tb in fillingSubscribe)
                        {
                            tb.State = States.FILLING;
                        }
                        break;
                    case States.REGULATING:
                        _state = value;
                        foreach (TouchButton tb in regulatingSubscribe)
                        {
                            tb.State = States.REGULATING;
                        }
                        break;
                    case States.EMPTYING:
                        _state = value;
                        foreach (TouchButton tb in emptySubscribe)
                        {
                            tb.State = States.EMPTYING;
                        }
                        break;
                }
            }
        }

        private ArrayList standbySubscribe;
        private ArrayList alarmSubscribe;
        private ArrayList fillingSubscribe;
        private ArrayList regulatingSubscribe;
        private ArrayList emptySubscribe;

        public event EventHandler? WindowClosed;
        public event PropertyChangedEventHandler? SetPointChanged;
        public event PropertyChangedEventHandler? ReadTempChanged;

        private double _setPointTemperature = 0;
        public double SetPointTemperature
        {
            get { return _setPointTemperature; }
            set
            {
                PropertyChangedEventHandler handler = SetPointChanged;
                if (handler == null) return;
                handler.Invoke(this, new PropertyChangedEventArgs(nameof(SetPointTemperature),_setPointTemperature,value));
                _setPointTemperature = value;
            }
        }

        private double _currentTemperature = 0;
        public double CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                PropertyChangedEventHandler handler = ReadTempChanged;
                if (handler == null) return;
                handler.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTemperature), _currentTemperature, value));
                _currentTemperature = value;
            }
        }

        private Active ActiveWindow
        {
            set
            {
                ActiveWindow = value;
                EventHandler handler = WindowClosed;
                if (handler == null) return;
                handler.Invoke(this, EventArgs.Empty);
                
                if (value == Active.MENU)
                {
                    ActiveWindow = value;
                    new MainMenuWindow(this);
                }

                if (value == Active.TEMPERATURE)
                {
                    ActiveWindow = value;
                    new TemperatureWindow(this);
                }
            }
            get =>  ActiveWindow;
        }

        public TouchButton[] ActiveButtons { get; set; }

        private enum Active
        {
            MENU, TEMPERATURE
        }
        public WindowModel()
        {
            Tough.InitializeScreen();
            Tough.TouchEvent += ToughOnTouchEvent;

            TouchButton menuSwitchButton = new TouchButton();
            TouchButton[] buttons =
            {
                menuSwitchButton,
                new TouchButton(),
                new TouchButton(),
                new TouchButton(),
                new TouchButton(),
                new TouchButton()
            };

            buttons[(int)Btn.MENU].ButtonPressed += OnArrow_Pressed;

            buttons[(int)Btn.FILL].ButtonPressed += OnFill_Pressed;

            buttons[(int)Btn.EMPTY].ButtonPressed += OnEmpty_Pressed;

            buttons[(int)Btn.PLUS].ButtonPressed += OnSetPointPlus_Pressed;

            buttons[(int)Btn.MINUS].ButtonPressed += OnSetPointMinus_Pressed;

            buttons[(int)Btn.REGULATE].ButtonPressed += OnRegulate_Pressed;
            

            ButtonContainer.Buttons = buttons;
            //_logic = new BusinessLogic();
            SetPointTemperature = 36.5;

            ActiveWindow = Active.TEMPERATURE;


        }

        private void ToughOnTouchEvent(object sender, TouchEventArgs e)
        {
            
            foreach (var btn in ActiveButtons)
            {
                if (btn.buttonRender.ContainsPoint(e.X, e.Y))
                {
                    btn.Press();
                }
            }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void OnArrow_Pressed(object sender, EventArgs e)
        {
            switch (ActiveWindow)
            {
                case Active.MENU:
                    ActiveWindow = Active.TEMPERATURE;
                    break;
                case Active.TEMPERATURE:
                    ActiveWindow = Active.MENU;
                    break;
            }
        }

        public void Subscribe(TouchButton tb,States state)
        {
            switch (state)
            {
                case States.STANDBY:
                    standbySubscribe.Add(tb);
                    break;
                case States.ALARM:
                    alarmSubscribe.Add(tb);
                    break;
                case States.FILLING:
                    fillingSubscribe.Add(tb);
                    break;
                case States.REGULATING:
                    regulatingSubscribe.Add(tb);
                    break;
                case States.EMPTYING:
                    emptySubscribe.Add(tb);
                    break;
            }
        }

        public void CheckTemperature() // Skal denne være her? andre måder? evt. skal metoden i logic sætte CurrentTemperature
        {
            _logic.CheckTemperature(SetPointTemperature);
        }

        public void OnEmpty_Pressed(object sender, EventArgs e)
        {
            if (_state != States.FILLING && _state != States.EMPTYING)
            {
                // Viser at reguler er inaktiv og tømfunktionen er aktiv
                _logic.EmptyVessel();
                _state = States.EMPTYING;
                // Viser at tømfunktionen er inaktiv
            }
            else
            {
                throw new Exception("Filling is active");
            }
        }

        public void OnFill_Pressed(object sender, EventArgs e)
        {
            if (_state == States.STANDBY)
            {
                // Viser at fyld funktion er aktiv
                _logic.FillVessel(SetPointTemperature);
                _state = States.FILLING;
                // Viser at fyld funktionen er inaktiv og reguler funktionen er aktiv

                // Viser at reguler funktion er inaktiv efter 5 timer
            }
            else
            {
                throw new Exception("Tub is not empty");
            }
        }

        public void OnRegulate_Pressed(object sender, EventArgs e)
        {
            if (_state == States.STANDBY)
            {
                _logic.RegulateTemperature(SetPointTemperature);  // SetPointTemperature skal databindes med displayet.
                _state = States.REGULATING;
                // Viser at regulering er aktiv

                // Efter 5 timer, viser at reguleringen er inaktiv
            }
            else
            {
                throw new Exception("Tub is either filling or emptying");
            }
        }

        public void OnSetPointMinus_Pressed(object sender, EventArgs e)
        {
            SetPointTemperature -= 0.5;
        }

        public void OnSetPointPlus_Pressed(object sender, EventArgs e)
        {
            SetPointTemperature += 0.5;
        }
    }
}
