using System;
using System.Device.Gpio;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    public abstract class Shape
    {
        public Point MiddlePoint { get; protected set; }
        public Point[] Points { get; protected set; }
        public int Length { get; protected set; }
        public int Height { get; protected set; }
        protected Shape(Point middlePoint, int length, int heigth)
        {
            MiddlePoint = middlePoint;
            Length = length;
            Height = heigth;
        }

        protected virtual void SetPoints()
        {
            Points = new Point[] { MiddlePoint };
        }

        public abstract Pixel[] GetOutline(ushort outlineThickness,ushort color);

        public abstract Pixel[] GetFill(ushort subtractOutline, ushort color);

    }
}
