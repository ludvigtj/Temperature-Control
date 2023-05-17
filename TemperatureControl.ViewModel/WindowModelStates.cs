using System.Collections;
using TemperatureControl.View.Elements;

namespace TemperatureControl.ViewModel
{
    public partial class WindowModel
    {
        private States _state;
        private void ChangeStateAndNotify(States newState)
        {
            switch (newState)
            {
                case States.STANDBY:
                    _state = newState;
                    foreach (TouchButton tb in standbySubscribe)
                    {
                        tb.State = States.STANDBY;
                    }
                    break;
                case States.ALARM:
                    _state = newState;
                    foreach (TouchButton tb in alarmSubscribe)
                    {
                        tb.State = States.ALARM;
                    }
                    break;
                case States.FILLING:
                    _state = newState;
                    foreach (TouchButton tb in fillingSubscribe)
                    {
                        tb.State = States.FILLING;
                    }
                    break;
                case States.REGULATING:
                    _state = newState;
                    foreach (TouchButton tb in regulatingSubscribe)
                    {
                        tb.State = States.REGULATING;
                    }
                    break;
                case States.EMPTYING:
                    _state = newState;
                    foreach (TouchButton tb in emptySubscribe)
                    {
                        tb.State = States.EMPTYING;
                    }
                    break;
            }
        }
        private ArrayList standbySubscribe;
        private ArrayList alarmSubscribe;
        private ArrayList fillingSubscribe;
        private ArrayList regulatingSubscribe;
        private ArrayList emptySubscribe;
        public void Subscribe(TouchButton tb, States state)
        {
            switch (state)
            {
                case States.STANDBY:
                    standbySubscribe.Add(tb);
                    break;
                case States.ALARM:
                    alarmSubscribe.Add(tb);
                    break;
                case States.FILLING:
                    fillingSubscribe.Add(tb);
                    break;
                case States.REGULATING:
                    regulatingSubscribe.Add(tb);
                    break;
                case States.EMPTYING:
                    emptySubscribe.Add(tb);
                    break;
            }
        }
    }
}