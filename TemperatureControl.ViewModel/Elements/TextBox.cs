using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Elements
{
    public class TextBox : Rectangle, ITextContent
    {
        public bool DrawBox = true;

        public TextBox(int x, int y, string text) : base(x, y)
        {
            _text = text;
        }
        private static Font _font = Resource.GetFont(Resource.FontResources.courierregular10);
        private DrawingContext _dc;
        public TextBox(int x, int y, string text, bool drawBox) : base(x, y)
        {
            DrawBox = drawBox;
        }

        private string _text = "Waiting";

        public void OnUpdateTextEvent(object sender, PropertyChangedEventArgs e)
        {
            _text = e.NewValue.ToString();
            PrintText();
        }
        public override void OnRender(DrawingContext dc)
        {
            _dc = dc;
            base.OnRender(dc);
            PrintText();
        }

        private void PrintText()
        {
            _dc.DrawText(ref _text, _font, Color.White, Width / 2, Height / 2, Width / 10, Height / 10, TextAlignment.Center, TextTrimming.CharacterEllipsis);
        }

    }
}