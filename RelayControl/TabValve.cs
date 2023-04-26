using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class TabValve: IValve
    {
        private readonly RelayController _relay;
        public TabValve(RelayController relay)
        {
            _relay = relay;
        }
        public void OpenValve()
        {
            _relay.TurnOnRelay(3);
        }

        public void CloseValve()
        {
            _relay.TurnOffRelay(3);
        }
    }
}
