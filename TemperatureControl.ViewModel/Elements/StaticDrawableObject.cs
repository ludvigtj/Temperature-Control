using TemperatureControl.ViewModel.Shapes;

namespace TemperatureControl.ViewModel.Elements
{
    public class StaticDrawableObject: DrawableObject
    {
        private Shape _drawObject;
        public StaticDrawableObject()
        {
            DrawType = DrawingType.STATIC;
        }
        protected override void getBuffer()
        {
            throw new System.NotImplementedException();
        }
    }
}