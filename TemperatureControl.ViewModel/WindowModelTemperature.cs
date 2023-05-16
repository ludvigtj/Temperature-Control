using nanoFramework.UI;

namespace TemperatureControl.ViewModel
{
    public partial class WindowModel
    {
        public event PropertyChangedEventHandler? SetPointChanged;
        public event PropertyChangedEventHandler? ReadTempChanged;
        private double _setPointTemperature = 0;
        public double SetPointTemperature
        {
            get
            {
                if (_setPointTemperature == 0) _setPointTemperature = 36.5;
                return _setPointTemperature;
            }
            set
            {
                PropertyChangedEventHandler handler = SetPointChanged;
                if (handler == null) return;
                handler.Invoke(this, new PropertyChangedEventArgs(nameof(SetPointTemperature), _setPointTemperature, value));
                _setPointTemperature = value;
            }
        }

        private double _currentTemperature = 0;
        public double CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                PropertyChangedEventHandler handler = ReadTempChanged;
                if (handler == null) return;
                handler.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTemperature), _currentTemperature, value));
                _currentTemperature = value;
            }
        }
    }
}