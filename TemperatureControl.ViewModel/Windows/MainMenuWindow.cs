using System;
using System.IO;
using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using nanoFramework.UI;
using TemperatureControl.ViewModel.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public class MainMenuWindow : MenuWindow
    {
        private enum BtnLocal
        {
            MENU = 0, FILL = 1, EMPTY = 2
        }
        public MainMenuWindow(IViewModel model) : base(model)
        {
            //RETRIEVING TOUCH BUTTONS FROM STATIC HOLDER
            LocalButtons = new[]
            {
                TouchButtons[(int)Btn.MENU],
                TouchButtons[(int)Btn.FILL],
                TouchButtons[(int)Btn.EMPTY]
            };
            //CREATING FULL SCREEN CANVAS
            Canvas c = new Canvas();
            this.Child = c;
            this.Background = new SolidColorBrush(ColorUtility.ColorFromRGB(0, 0, 0));

            //CREATING GRAPHIC PORTION OF TOUCH BUTTONS
            int standardWidth = (Width / 2) - 1;
            int standardHeight = (Height / 2) - 1;

            LocalButtons[(int)BtnLocal.MENU].buttonRender = new Rectangle(standardWidth, standardHeight)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            LocalButtons[(int)BtnLocal.FILL].buttonRender = new Rectangle(standardWidth, standardHeight)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            LocalButtons[(int)BtnLocal.EMPTY].buttonRender = new Rectangle(standardWidth, standardHeight)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            TextBox tempString = new TextBox(standardWidth, standardHeight, false);


            //SETTING LOCALTION OF ELEMENTS ON THE CANVAS
            Canvas.SetLeft(tempString, 0);
            Canvas.SetTop(tempString, 0);
            c.Children.Add(tempString);
            model.ReadTempChanged += tempString.OnUpdateTextEvent;

            Canvas.SetLeft(LocalButtons[(int)BtnLocal.FILL].buttonRender, 0);
            Canvas.SetTop(LocalButtons[(int)BtnLocal.FILL].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.FILL].buttonRender);

            Canvas.SetRight(LocalButtons[(int)BtnLocal.EMPTY].buttonRender, 0);
            Canvas.SetTop(LocalButtons[(int)BtnLocal.EMPTY].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.EMPTY].buttonRender);

            Canvas.SetRight(LocalButtons[(int)BtnLocal.MENU].buttonRender, 0);
            Canvas.SetBottom(LocalButtons[(int)BtnLocal.MENU].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.MENU].buttonRender);
            model.ActiveButtons = LocalButtons;
        }
    }
}