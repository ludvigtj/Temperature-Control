using nanoFramework.UI;

namespace TemperatureControl.ViewModel.Interfaces
{
    public interface IBusinessLogic
    {
        bool IsRegulating { get; set; }
        double CurrentTemperature { get; set; } // CurrentTemperature skal databindes med displayet.
        double SetPointTemperature { get; set; } // SetPointTemperature skal databindes med displayet.
        event PropertyChangedEventHandler CurrentTemperatureChanged;
        event PropertyChangedEventHandler SetPointTemperatureChanged;
        void FillVessel();
        void EmptyVessel();
        void RegulateTemperature();
        void CheckTemperature();
    }
}