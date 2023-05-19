using System;
using System.Diagnostics;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using nanoFramework.UI.Threading;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Elements
{
    public class TextBox : ITextContent
    {
        public TextBox(string text)
        {
            Content = new Text(_font, text)
            {
                ForeColor = Color.White
            };

        }

        private static Font _font = Resource.GetFont(Resource.FontResources.courierregular10);
        public Text Content { get; private set; }

        public void OnUpdateTextEvent(object sender, PropertyChangedEventArgs e)
        {
            string a = e.NewValue.ToString();
            Content.TextContent = a;
            Content.Invalidate();

        }


    }
}