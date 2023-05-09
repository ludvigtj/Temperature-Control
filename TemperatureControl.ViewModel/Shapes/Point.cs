using System;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    internal class Point
    {
        private const int _xHardwareLimit = 320;
        private const int _yHardwareLimit = 240;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            if (X < 0) X = 0;
            if (Y < 0) Y = 0;
            if (X > _xHardwareLimit) X = _xHardwareLimit;
            if (Y > _yHardwareLimit) Y = _yHardwareLimit;
            
        }
        public int X { get; set; }
        public int Y { get; set; }

        public string GetCoords()
        {
            return $"{X},{Y}";
        }
    }
}
