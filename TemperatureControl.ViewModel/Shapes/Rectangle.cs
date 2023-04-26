using System;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    internal class Rectangle : Shape
    {
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;
        public Point MiddlePoint;
        public int Length;
        public int Breadth;
        public int Area;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
            TopRight = new Point()
            {
                X = BottomRight.X,
                Y = TopLeft.Y
            };
            BottomLeft = new Point()
            {
                X = TopLeft.X,
                Y = BottomRight.Y
            };
            Length = bottomRight.X - TopLeft.X;
            Breadth = TopLeft.Y - BottomRight.Y;
            Area = Length * Breadth;
            MiddlePoint = new Point()
            {
                X = TopLeft.X + Length/2,
                Y = BottomRight.Y + Breadth/2
            };
        }

        private bool BetweenRanges(int a, int b, int input)
        {
            return (a <= input) && (input <= b);
        }

        public bool IsPointWithinArea(Point input)
        {
            return (BetweenRanges(TopLeft.X,TopRight.X,input.X) && BetweenRanges(BottomLeft.Y, TopLeft.Y, input.Y));
        }
    }
}
