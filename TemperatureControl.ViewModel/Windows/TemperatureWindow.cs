using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using System;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Shapes;
using TemperatureControl.ViewModel.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public class TemperatureWindow : MenuWindow
    {
        public TemperatureWindow(IViewModel model) : base(model)
        {
            Rectangle newR = new Rectangle();
        }

        protected override void OnSwitchWindows(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void DefineRenders()
        {
            ////CREATING FULL SCREEN CANVAS
            //Canvas c = new Canvas();
            //this.Child = c;
            //this.Background = new SolidColorBrush(ColorUtility.ColorFromRGB(0, 0, 0));

            //int standardWidth = (Width / 2) - 1;
            //int standardHeight = (Height / 2) - 1;

            ////TextBox
            //TextBox tempString = new TextBox(standardWidth, standardHeight, "...", c);
            //Canvas.SetLeft(tempString.Content, 0);
            //Canvas.SetTop(tempString.Content, 0);
            //c.Children.Add(tempString.Content);
            //c.Children.Add(tempString.Content);
            //viewModel.SetPointChanged += tempString.OnUpdateTextEvent;

            //TouchButton tbMenu = new TouchButton()
            //{
            //    ButtonRender = new TextBox(standardWidth, standardHeight, "MENU")
            //    {
            //        Fill = new SolidColorBrush(Color.Black),
            //        Stroke = new Pen(Color.White)
            //    }
            //};
            //tbMenu.ButtonPressed += OnSwitchWindows;

            //Canvas.SetRight(tbMenu., 0);
            //Canvas.SetBottom(tbMenu., 0);
            //c.Children.Add(tbMenu.);

            //TouchButton tbRegulate = new TouchButton()
            //{
            //    ButtonRender = new TextBox(standardWidth, standardHeight, "REGULER")
            //    {
            //        Fill = new SolidColorBrush(Color.Black),
            //        Stroke = new Pen(Color.White)
            //    }
            //};
            //tbRegulate.ButtonPressed += viewModel.OnRegulate_Pressed;
            //viewModel.Subscribe(tbRegulate, States.REGULATING);

            //Canvas.SetRight(tbRegulate, 0);
            //Canvas.SetTop(tbRegulate, 0);
            //c.Children.Add(tbRegulate);

            //TouchButton tbPlus = new PlusSign((standardWidth / 2) - 1, (standardHeight / 2) - 1)
            //{
            //    Fill = new SolidColorBrush(Color.Black),
            //    Stroke = new Pen(Color.White)
            //};
            //tbPlus.ButtonPressed += viewModel.OnSetPointPlus_Pressed;
            //Canvas.SetLeft(tbPlus, (standardWidth / 2) + 1);
            //Canvas.SetBottom(tbPlus, 0);
            //c.Children.Add(tbPlus);

            //TouchButton tbMinus = new MinusSign((standardWidth / 2) - 1, (standardHeight / 2) - 1)
            //{
            //    Fill = new SolidColorBrush(Color.Black),
            //    Stroke = new Pen(Color.White)
            //};

            //tbMinus.ButtonPressed += viewModel.OnSetPointMinus_Pressed;

            //Canvas.SetLeft(tbMinus, 0);
            //Canvas.SetBottom(tbMinus, 0);
            //c.Children.Add(tbMinus);
            //LocalButtons = new[] { tbMenu, tbRegulate, tbMinus, tbPlus };
        }
    }
}