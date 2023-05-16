using System;
using System.Text;

namespace TemperatureControl.ViewModel.Interfaces
{
    public interface IViewController
    {
        IViewModel ViewModel { get; }
    }
}
