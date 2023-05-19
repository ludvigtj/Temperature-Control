using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using System;
using nanoFramework.Presentation.Controls;
using TemperatureControl.ViewModel;

namespace TemperatureControl.ViewModel.Elements
{
    public class MenuButton : TouchButton
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
            }
        }

        private Pen _outlinePen;
        private SolidColorBrush _fillBrush;
        private int X;
        private int Y;

        public TextBox Text;
        public MenuButton(Canvas canvas, int x, int y) : base(x,y)
        {
            
        }

    }
}