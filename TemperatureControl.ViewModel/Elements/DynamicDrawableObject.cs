using System;

namespace TemperatureControl.ViewModel.Elements
{
    public abstract class DynamicDrawableObject: DrawableObject
    {
        protected ushort _stateCount;
        protected StaticDrawableObject[] _stateDrawableObjects;
        //Databind text??

        protected DynamicDrawableObject(StaticDrawableObject[] stateDrawableObjects, ushort stateCount)
        {
            DrawType = DrawingType.DYNAMIC;
            _stateCount = stateCount;
            _stateDrawableObjects = stateDrawableObjects;
        }

        protected DynamicDrawableObject(StaticDrawableObject[] stateDrawableObjects)
        {
            _stateDrawableObjects = stateDrawableObjects ?? throw new ArgumentNullException(nameof(stateDrawableObjects));
            _stateCount = (ushort)_stateDrawableObjects.Length;
        }

        public abstract void GetBufferForState(ushort state);

        protected override void getBuffer()
        {
            throw new System.NotImplementedException();
        }
    }
}