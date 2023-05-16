using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.Presentation.Shapes;
using TemperatureControl.View.Elements;
using TemperatureControl.ViewModel.Elements;
using TemperatureControl.ViewModel.Interfaces;

namespace TemperatureControl.ViewModel.Windows
{
    public class TemperatureWindow : MenuWindow
    {
        private enum BtnLocal
        {
            MENU = 0, REGULATE = 1, PLUS = 2, MINUS = 3
        }
        public TemperatureWindow(IViewModel model) : base(model)
        {
            //RETRIEVING TOUCH BUTTONS FROM STATIC HOLDER
            LocalButtons = new[]
            {
                TouchButtons[(int)Btn.MENU],
                TouchButtons[(int)Btn.REGULATE],
                TouchButtons[(int)Btn.PLUS],
                TouchButtons[(int)Btn.MINUS]
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
            LocalButtons[(int)BtnLocal.REGULATE].buttonRender = new Rectangle(standardWidth, standardHeight)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            LocalButtons[(int)BtnLocal.PLUS].buttonRender = new PlusSign((standardWidth / 2) - 1, (standardHeight / 2) - 1)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            LocalButtons[(int)BtnLocal.MINUS].buttonRender = new MinusSign((standardWidth / 2)-1, (standardHeight / 2) - 1)
            {
                Fill = new SolidColorBrush(Color.Black),
                Stroke = new Pen(Color.White)
            };
            TextBox tempString = new TextBox(standardWidth, standardHeight, false);

            //SETTING LOCALTION OF ELEMENTS ON THE CANVAS
            Canvas.SetLeft(tempString, 0);
            Canvas.SetTop(tempString,0);
            c.Children.Add(tempString);
            model.SetPointChanged += tempString.OnUpdateTextEvent;

            Canvas.SetRight(LocalButtons[(int)BtnLocal.REGULATE].buttonRender, 0);
            Canvas.SetTop(LocalButtons[(int)BtnLocal.REGULATE].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.REGULATE].buttonRender);

            Canvas.SetLeft(LocalButtons[(int)BtnLocal.PLUS].buttonRender, (standardWidth / 2)+1);
            Canvas.SetBottom(LocalButtons[(int)BtnLocal.PLUS].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.PLUS].buttonRender);

            Canvas.SetLeft(LocalButtons[(int)BtnLocal.MINUS].buttonRender, 0);
            Canvas.SetBottom(LocalButtons[(int)BtnLocal.MINUS].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.MINUS].buttonRender);

            Canvas.SetRight(LocalButtons[(int)BtnLocal.MENU].buttonRender, 0);
            Canvas.SetBottom(LocalButtons[(int)BtnLocal.MENU].buttonRender, 0);
            c.Children.Add(LocalButtons[(int)BtnLocal.MENU].buttonRender);
            model.ActiveButtons = LocalButtons;
        }
    }
}