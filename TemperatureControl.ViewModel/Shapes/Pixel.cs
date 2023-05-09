using System;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    internal class Pixel: Point
    {
        

        public int Color { get; private set; }
        public Pixel(int x, int y, int color) : base(x, y)
        {
            Color = color;
        }
    }
}
