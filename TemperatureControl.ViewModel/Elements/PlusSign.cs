using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;

namespace TemperatureControl.ViewModel.Elements
{
    public class PlusSign : TouchButton
    {
        public PlusSign(int x, int y) : base(x, y) { }


        public override void OnRender(DrawingContext dc)
        {
            int xH0 = Width / 4;
            int xH1 = xH0 + (Width / 2);
            int yH = Height / 2;

            int xV = Width / 2;
            int yV0 = Height / 4;
            int yV1 = yV0 + (Height / 2);

            //Horizontal line
            dc.DrawLine(new Pen(Color.White), xH0, yH, xH1, yH);
            //Vertical line
            dc.DrawLine(new Pen(Color.White), xV, yV0, xV, yV1);
        }
    }
}