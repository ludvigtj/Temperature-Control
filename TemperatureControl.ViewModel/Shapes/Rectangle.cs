using System;
using System.Diagnostics;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    internal class Rectangle : Shape
    {
        public Point TopLeft { get; private set; }
        public Point TopRight { get; private set; }
        public Point BottomLeft { get; private set; }
        public Point BottomRight { get; private set; }

        public int Area
        {
            get
            {
                return Length * Height;
            }
            
        }

        public Rectangle(Point middlePoint, int length, int heigth)
            :base(middlePoint,length, heigth)
        {
            
        }

        protected override void SetPoints()
        {
            //Check if radius exceeds screen bounds
            CheckRadius();

            int x = MiddlePoint.X - _xRadius;
            int y = MiddlePoint.Y + _yRadius;
            TopLeft = new Point(x, y);

            x = MiddlePoint.X + _xRadius;
            y = MiddlePoint.Y + _yRadius;
            TopRight = new Point(x, y);

            x = MiddlePoint.X - _xRadius;
            y = MiddlePoint.Y - _yRadius;
            BottomLeft = new Point(x, y);

            x = MiddlePoint.X + _xRadius;
            y = MiddlePoint.Y - _yRadius;
            BottomRight = new Point(x, y);

            Points = new Point[]
            {
                MiddlePoint, //0
                TopLeft, //1
                TopRight, //2
                BottomLeft, //3
                BottomRight //4
            };
        }

        private bool BetweenRanges(int a, int b, int input)
        {
            return (a <= input) && (input <= b);
        }

        public override bool IsPointWithinArea(Point input)
        {
            return (BetweenRanges(TopLeft.X, TopRight.X, input.X) && BetweenRanges(BottomLeft.Y, TopLeft.Y, input.Y));
        }

        private void CheckRadius()
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            if (MiddlePoint.X + _xRadius > 320) x1 = 320 - MiddlePoint.X;
            if (MiddlePoint.X - _xRadius < 0) x2 = MiddlePoint.X;
            if (x1 < x2 && x1 != 0) _xRadius = x1;
            if (x2 < x1 && x2 != 0) _xRadius = x2;

            if (MiddlePoint.Y + _yRadius > 240) y1 = 240 - MiddlePoint.Y;
            if (MiddlePoint.Y - _yRadius < 0) y2 = MiddlePoint.Y;
            if (y1 < y2 && y1 != 0) _yRadius = y1;
            if (y2 < y1 && y2 != 0) _yRadius = y2;
            Debug.WriteLine($"Found outofscope:{x1},{x2},{y1},{y2}");
        }

        public override Pixel[] GetOutline(ushort outlineThickness, ushort color)
        {
            throw new NotImplementedException();
            int Circumference = 2 * Length + 2 * Height;
            int bufferSize = (Circumference * outlineThickness) - 8 * outlineThickness;
            Pixel[] output = new Pixel[bufferSize];
            int n = 0;
            //ArrayOrder??
            for (int t = 0; t < outlineThickness; t++)
            {
                for (int i = 0; i < Length; i++)
                {
                    output[n] = new Pixel(TopLeft.X + i, TopLeft.Y - t, color);
                    n++;
                }
            }
        }

        public override Pixel[] GetFill(ushort subtractOutline, ushort color)
        {
            int newHeight = 1 + Height - subtractOutline;
            int newLength = 1 + Length - subtractOutline;
            int bufferSize = newLength * newHeight;
            int startX = TopLeft.X + subtractOutline;
            int startY = TopLeft.Y - subtractOutline;

            int n = 0;
            Pixel[] output = new Pixel[bufferSize];

            for (int i = 0; i <= newHeight; i++)
            {

                for (int j = 0; j <= newLength; j++)
                {
                    output[n] = new Pixel(startX + j, startY - i, color);
                    n++;
                }
            }
            return output;
        }

    }



}
