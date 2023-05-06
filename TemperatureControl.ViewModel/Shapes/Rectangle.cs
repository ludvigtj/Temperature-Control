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
