using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using System;
using TemperatureControl.ViewModel;

namespace TemperatureControl.View.Elements
{
    public class TouchButton : ITouchButton
    {
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
                    case States.STANDBY:
                        ;
                        break;
                }
                ButtonRender.Fill = new SolidColorBrush(c);
            }
        }
        public event EventHandler ButtonPressed;
        public Rectangle ButtonRender { get; set; }
        public TouchButton()
        {

        }

        public void Press()
        {
            EventHandler handler = ButtonPressed;
            if (handler == null) return;
            handler.Invoke(this, EventArgs.Empty);
        }

    }
}