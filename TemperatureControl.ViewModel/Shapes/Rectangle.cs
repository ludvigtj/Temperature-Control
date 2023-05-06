using System;
using System.Text;

namespace TemperatureControl.ViewModel.Shapes
{
    public class Rectangle : Shape
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
            SetPoints();
        }

        protected override void SetPoints()
        {
            int x = MiddlePoint.X - Length / 2;
            int y = MiddlePoint.Y + Height / 2;
            TopLeft = new Point(x, y);
            
            x = MiddlePoint.X + Length / 2;
            y = MiddlePoint.Y + Height / 2;
            TopRight = new Point(x, y);

            x = MiddlePoint.X - Length / 2;
            y = MiddlePoint.Y - Height / 2;
            BottomLeft = new Point(x, y);

            x = MiddlePoint.X + Length / 2;
            y = MiddlePoint.Y - Height / 2;
            BottomRight = new Point(x, y);

            Points = new Point[]
            {
                MiddlePoint,
                TopLeft,
                TopRight,
                BottomLeft,
                BottomRight
            };
        }

        public override Pixel[] GetOutline(ushort outlineThickness, ushort color)
        {
            int Circumference = 2 * Length + 2 * Height;
            int bufferSize = (Circumference * outlineThickness)-8*outlineThickness;
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
            int newHeight = Height - subtractOutline;
            int newLength = Length - subtractOutline;
            int bufferSize = newLength * newHeight;
            int startX = TopLeft.X + subtractOutline;
            int startY = TopLeft.Y - subtractOutline;

            Pixel[] output = new Pixel[bufferSize];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    output[(j+1)*(i+1)] = new Pixel(startX + j, startY + i, color);
                }
            }

            return output;
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
