using nanoFramework.Presentation.Media;

namespace TemperatureControl.ViewModel.Elements
{
    public class MinusSign : TouchButton
    {
        public MinusSign(int x, int y) : base(x, y) { }

        public override void OnRender(DrawingContext dc)
        {
            int xH0 = Width / 4;
            int xH1 = xH0 + (Width / 2);
            int yH = Height / 2;
            //Horizontal line
            dc.DrawLine(new Pen(Color.White), xH0, yH, xH1, yH);
        }
    }
}