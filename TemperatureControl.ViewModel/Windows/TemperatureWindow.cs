using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using System;
using TemperatureControl.View.Elements;
using TemperatureControl.ViewModel.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public class TemperatureWindow : MenuWindow
    {
        public TemperatureWindow(IViewModel model) : base(model)
        {

        }

        protected override void OnSwitchWindows(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void DefineRenders()
        {
            //CREATING FULL SCREEN CANVAS
            Canvas c = new Canvas();
            this.Child = c;
            this.Background = new SolidColorBrush(ColorUtility.ColorFromRGB(0, 0, 0));

            int standardWidth = (Width / 2) - 1;
            int standardHeight = (Height / 2) - 1;

            //TextBox
            TextBox tempString = new TextBox(standardWidth, standardHeight, "...", false);
            Canvas.SetLeft(tempString, 0);
            Canvas.SetTop(tempString, 0);
            c.Children.Add(tempString);
            viewModel.SetPointChanged += tempString.OnUpdateTextEvent;

            TouchButton tbMenu = new TouchButton()
            {
                ButtonRender = new TextBox(standardWidth, standardHeight, "MENU")
                {
                    Fill = new SolidColorBrush(Color.Black),
                    Stroke = new Pen(Color.White)
                }
            };
            tbMenu.ButtonPressed += OnSwitchWindows;

            Canvas.SetRight(tbMenu.ButtonRender, 0);
            Canvas.SetBottom(tbMenu.ButtonRender, 0);
            c.Children.Add(tbMenu.ButtonRender);

            TouchButton tbRegulate = new TouchButton()
            {
                ButtonRender = new TextBox(standardWidth, standardHeight, "REGULER")
                {
                    Fill = new SolidColorBrush(Color.Black),
                    Stroke = new Pen(Color.White)
                }
            };
            tbRegulate.ButtonPressed += viewModel.OnRegulate_Pressed;
            viewModel.Subscribe(tbRegulate, States.REGULATING);

            Canvas.SetRight(tbRegulate.ButtonRender, 0);
            Canvas.SetTop(tbRegulate.ButtonRender, 0);
            c.Children.Add(tbRegulate.ButtonRender);

            TouchButton tbPlus = new TouchButton()
            {
                ButtonRender = new PlusSign((standardWidth / 2) - 1, (standardHeight / 2) - 1)
                {
                    Fill = new SolidColorBrush(Color.Black),
                    Stroke = new Pen(Color.White)
                }
            };
            tbPlus.ButtonPressed += viewModel.OnSetPointPlus_Pressed;

            Canvas.SetLeft(tbPlus.ButtonRender, (standardWidth / 2) + 1);
            Canvas.SetBottom(tbPlus.ButtonRender, 0);
            c.Children.Add(tbPlus.ButtonRender);

            TouchButton tbMinus = new TouchButton()
            {
                ButtonRender = new MinusSign((standardWidth / 2) - 1, (standardHeight / 2) - 1)
                {
                    Fill = new SolidColorBrush(Color.Black),
                    Stroke = new Pen(Color.White)
                }
            };
            tbMinus.ButtonPressed += viewModel.OnSetPointMinus_Pressed;

            Canvas.SetLeft(tbMinus.ButtonRender, 0);
            Canvas.SetBottom(tbMinus.ButtonRender, 0);
            c.Children.Add(tbMinus.ButtonRender);
            LocalButtons = new[] { tbMenu, tbRegulate, tbMinus, tbPlus };
        }
    }
}