using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using DesertRage.ViewModel.Battle.Participation;

namespace DesertRage.ViewModel.Battle
{
    public class Timing : INotifyPropertyChanged
    {
        private protected Timing()
        {
            _timing = new DispatcherTimer();
            _timing.Interval = new TimeSpan(0, 0, 0, 0, 50);
        }

        #region Event Members

        #region Poison
        internal void HealPoison(in Participant unit)
        {
            _timing.Tick -= unit.Poison;
            unit.SetPoison(false);
        }

        internal void Poison(in Participant unit)
        {
            if (unit.IsPoisoned)
                return;

            _timing.Tick += unit.Poison;
            unit.SetPoison(true);
        }
        #endregion

        #region Turns
        private protected void EndTurns(in Participant unit)
        {
            _timing.Tick -= unit.WaitForTurn;
            HealPoison(unit);
        }

        private protected void StartTurns(in Participant unit)
        {
            _timing.Tick += unit.WaitForTurn;
        }
        #endregion

        #endregion

        #region Timing Members
        internal virtual void Pause()
        {
            _timing.Stop();
        }

        internal virtual void Resume()
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