namespace TemperatureControl.RelayControl.Interfaces
{
    public interface IValve
    {
        bool ValveOpen { get; }
        void OpenValve();
        void CloseValve();
    }
}