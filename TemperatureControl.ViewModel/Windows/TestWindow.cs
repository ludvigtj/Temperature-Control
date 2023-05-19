using System;
using System.Diagnostics;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Tough;
using nanoFramework.UI;
using TemperatureControl.ViewModel.Elements;

namespace TemperatureControl.ViewModel.Windows
{
    public class TestWindow : MenuWindow
    {
        private TouchButton updateOnTouchButton;
        private PropertyChangedEventHandler propertyChangedEventArgs;
        private TextBox text;
        private int n = 0;
        public string Text { get => Text;
            set
            {
                PropertyChangedEventHandler handler = propertyChangedEventArgs;
                if (handler == null) return;
                handler.Invoke(this, new PropertyChangedEventArgs(nameof(Text), Text, value));
            }
        }
        public TestWindow()
        {
            this.Visibility = Visibility.Visible;
            this.Width = DisplayControl.ScreenWidth;
            this.Height = DisplayControl.ScreenHeight;
            DefineRenders();
        }

        protected override void OnSwitchWindows(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void DefineRenders()
        {
            Canvas c = new Canvas();
            this.Child = c;
            this.Background = new SolidColorBrush(Color.Black);
            updateOnTouchButton = new TouchButton(Width / 2, Height / 2)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            
            c.Children.Add(updateOnTouchButton);
            text = new TextBox( "Hello");
            propertyChangedEventArgs += text.OnUpdateTextEvent;
            Canvas.SetRight(text.Content,0);
            Canvas.SetBottom(text.Content,0);
            c.Children.Add(text.Content);


        }

        public override void ToughOnTouchEvent(object sender, TouchEventArgs e)
        {
            //if (n % 2 == 0)
            //{
            //    updateOnTouchButton = new TouchButton(Width / 2, Height / 2)
            //    {
            //        Fill = new SolidColorBrush(Color.Green),
            //        Stroke = new Pen(Color.White)
            //    };
            //}
            //updateOnTouchButton = new TouchButton(Width / 2, Height / 2)
            //{
            //    Fill = new SolidColorBrush(Color.Black),
            //    Stroke = new Pen(Color.White)
            //};
            Text = "Hello" + n;
            n++;
            Debug.WriteLine("Touched");
        }
        
    }
}