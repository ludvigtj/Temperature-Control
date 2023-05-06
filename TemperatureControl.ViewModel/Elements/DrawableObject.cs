using System;
using System.Text;
using nanoFramework.Presentation.Media;

namespace TemperatureControl.ViewModel.Elements
{
    public abstract class DrawableObject
    {
         public enum DrawingType
         {
             STATIC,
             DYNAMIC
         }
        public DrawingType DrawType { get; protected set; }
        protected abstract void getBuffer();
    }
}
