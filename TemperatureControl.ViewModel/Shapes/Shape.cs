using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    internal abstract class Shape
    {
        public Point MiddlePoint { get; protected set; }
        public Point[] Points { get; protected set; }
        public int Length { get; protected set; }
        public int Height { get; protected set; }
        protected int _xRadius = 0;
        protected int _yRadius = 0;
        protected Shape(Point middlePoint, int xRadius, int yRadius)
        {

            _xRadius = xRadius;
            _yRadius = yRadius;
            MiddlePoint = middlePoint;
            Length = 1 + 2 * xRadius;
            Height = 1 + 2* yRadius;

            
            SetPoints();
        }

        protected abstract void SetPoints();

        public abstract bool IsPointWithinArea(Point input);

        public abstract Pixel[] GetOutline(ushort outlineThickness,ushort color);

        public abstract Pixel[] GetFill(ushort subtractOutline, ushort color);

    }
}
