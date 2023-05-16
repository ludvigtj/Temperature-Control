using System;
using System.Diagnostics;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using TemperatureControl.ViewModel;

namespace TemperatureControl.View.Elements
{
    public class TouchButton: ITouchButton
    {
        public string Text { get; set; }

        private Text _text;
        private bool[] _subscribedStates;
        public States State
        {
            get => State;
            set
            {
                Color c = Color.Black;
                switch (value)
                {
                    case States.ALARM:
                        c = Color.Red;
                        break;
                    case States.EMPTYING:
                        c = Color.Green;
                        break;
                    case States.FILLING:
                        c = Color.Green;
                        break;
                    case States.REGULATING:
                        c = Color.Green;
                        break;
                    case States.STANDBY:;
                        break;
                }
                buttonRender.Fill = new SolidColorBrush(c);
            }
        }
        public event EventHandler ButtonPressed;
        public Rectangle buttonRender { get; set; }
        public TouchButton()
        {

        }

        public void Press()
        {
            OnButtonPressed();
        }

        protected void OnButtonPressed()
        {
            EventHandler handler = ButtonPressed;
            if (handler == null) return;
            handler.Invoke(this, EventArgs.Empty);

        }
        
    }
}