using System.Resources;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Elements
{
    public class TextBox : Rectangle, ITextContent
    {
        public bool DrawBox = true;
        public TextBox(int x, int y) : base(x,y) { }
        private static Font _font = Resource.GetFont(Resource.FontResources.courierregular10);
        public TextBox(int x, int y, bool drawBox) : base(x, y)
        {
            DrawBox = drawBox;
        }
        private string _text = ".oOo.";

        public void OnUpdateTextEvent(object sender, PropertyChangedEventArgs e)
        {
            _text = e.NewValue.ToString();
        }
        public override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            dc.DrawText(ref _text, _font, Color.White, Width / 2, Height / 2, Width / 10, Height / 10, TextAlignment.Center, TextTrimming.CharacterEllipsis);
        }
        
    }
}