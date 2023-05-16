namespace TemperatureControl.RelayControl.Interfaces
{
    public interface ITemperatureRegulator
    {
        double SetPointTemp { get; set; }
        void Regulate(double actualTemp);

    }
}