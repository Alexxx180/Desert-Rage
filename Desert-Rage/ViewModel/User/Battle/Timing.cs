using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using DesertRage.ViewModel.User.Battle.Components.Participation.Statuses;

namespace DesertRage.ViewModel.User.Battle
{
    public class Timing : INotifyPropertyChanged
    {
        /// <summary>
        /// Timing battle events attachment logic
        /// </summary>
        private protected Timing()
        {
            _timing = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 100)
            };
        }

        #region Event Members

        #region State Events
        public void AddStateEvent(in IStatusEvent status)
        {
            _timing.Tick += status.StateEvent;
        }

        public void RemoveStateEvent(in IStatusEvent status)
        {
            _timing.Tick -= status.StateEvent;
        }
        #endregion

        #region Turns
        private protected void EndTurns(in Participant unit)
        {
            _timing.Tick -= unit.WaitForTurn;
        }

        private protected void StartTurns(in Participant unit)
        {
            _timing.Tick += unit.WaitForTurn;
        }
        #endregion

        #endregion

        #region Timing Members
        private protected void Interrupt()
        {
            _timing.Stop();
        }

        protected internal void Continue()
        {
            _timing.Start();
        }

        private readonly DispatcherTimer _timing;
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
