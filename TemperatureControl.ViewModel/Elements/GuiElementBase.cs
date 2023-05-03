using System;
using System.Text;
using nanoFramework.Presentation.Shapes;

namespace TemperatureControl.ViewModel.Elements
{
    public abstract class GuiElementBase
    {
        private Rectangle area;
        public GuiElementBase(int x1, int y1, int x2, int y2)
        {
            area = new Rectangle();
        }
        
    }
}
