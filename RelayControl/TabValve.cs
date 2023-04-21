using System;
using RelayControl.Interfaces;

namespace RelayControl
{
    public class TabValve: IValve
    {
        private readonly RelayControl _relay;
        public TabValve(RelayControl relay)
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
