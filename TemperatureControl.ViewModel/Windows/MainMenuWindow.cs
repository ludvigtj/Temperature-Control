using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Tough;
using System;
using TemperatureControl.ViewModel.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public class MainMenuWindow : MenuWindow
    {

        public MainMenuWindow(IViewModel model) : base(model)
        {

        }
        protected override void OnSwitchWindows(object sender, EventArgs e)
        {
            MenuWindow temperatureWindow = new TemperatureWindow(viewModel);
        }

        public override void ToughOnTouchEvent(object sender, TouchEventArgs e)
        {

            base.ToughOnTouchEvent(sender, e);
        }

        protected override void DefineRenders()
        {
            //CREATING FULL SCREEN CANVAS
            //Canvas c = new Canvas();
            //this.Child = c;
            //this.Background = new SolidColorBrush(ColorUtility.ColorFromRGB(0, 0, 0));

            //int standardWidth = (Width / 2) - 1;
            //int standardHeight = (Height / 2) - 1;
            //TextBox tempString = new TextBox(standardWidth, standardHeight, "...", false);
            //viewModel.ReadTempChanged += tempString.OnUpdateTextEvent;
            //Canvas.SetLeft(tempString, 0);
            //Canvas.SetTop(tempString, 0);
            //c.Children.Add(tempString);

            //TouchButton tbMenu = new TouchButton()
            //{
            //    ButtonRender = new TextBox(standardWidth, standardHeight, "MENU")
            //    {
            //        Fill = new SolidColorBrush(Color.Black),
            //        Stroke = new Pen(Color.White)
            //    }
            //};
            //tbMenu.ButtonPressed += OnSwitchWindows;

            //Canvas.SetRight(tbMenu.ButtonRender, 0);
            //Canvas.SetBottom(tbMenu.ButtonRender, 0);
            //c.Children.Add(tbMenu.ButtonRender);

            //TouchButton tbFill = new TouchButton()
            //{
            //    ButtonRender = new TextBox(standardWidth, standardHeight, "FYLD")
            //    {
            //        Fill = new SolidColorBrush(Color.Black),
            //        Stroke = new Pen(Color.White)
            //    }
            //};
            //tbFill.ButtonPressed += viewModel.OnFill_Pressed;

            //viewModel.Subscribe(tbFill, States.FILLING);

            //Canvas.SetLeft(tbFill.ButtonRender, 0);
            //Canvas.SetTop(tbFill.ButtonRender, 0);
            //c.Children.Add(tbFill.ButtonRender);

            //TouchButton tbEmpty = new TouchButton()
            //{
            //    ButtonRender = new TextBox(standardWidth, standardHeight, "TØM")
            //    {
            //        Fill = new SolidColorBrush(Color.Black),
            //        Stroke = new Pen(Color.White)
            //    }
            //};
            //tbEmpty.ButtonPressed += viewModel.OnEmpty_Pressed;
            //viewModel.Subscribe(tbEmpty, States.EMPTYING);

            //Canvas.SetRight(tbEmpty.ButtonRender, 0);
            //Canvas.SetTop(tbEmpty.ButtonRender, 0);
            //c.Children.Add(tbEmpty.ButtonRender);
            //LocalButtons = new[] { tbMenu, tbFill, tbEmpty };
        }
    }
}