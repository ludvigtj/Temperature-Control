using nanoFramework.UI;
using System;

namespace TemperatureControl.ViewModel.Interfaces
{
    internal interface IBusinessLogic
    {
        event PropertyChangedEventHandler CurrentTemperatureChanged;
        event PropertyChangedEventHandler SetPointTemperatureChanged;
        double CurrentTemperature { get; set; } 
        double SetPointTemperature { get; set; }
        bool IsRegulating { get; set; }
        void FillVessel();
        void EmptyVessel();
        void RegulateTemperature();
        void CheckTemperature();
    }
}