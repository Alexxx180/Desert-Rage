using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace DesertRage.ViewModel.Battle
{
    public abstract class BattleOptions : INotifyPropertyChanged
    {
        private protected BattleOptions()
        {
            _timing = new DispatcherTimer();
            _timing.Interval = new TimeSpan(0, 0, 0, 0, 50);
            Enemies = new ObservableCollection<Enemy>();
        }

        #region Timing Members
        private readonly DispatcherTimer _timing;

        internal void HealPoison(in Participant unit)
        {
            System.Diagnostics.Trace.WriteLine("GOT IT!!");

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

        private protected void EndTurns(in Participant unit)
        {
            _timing.Tick -= unit.WaitForTurn;
            HealPoison(unit);
        }

        private protected void StartTurns(in Participant unit)
        {
            _timing.Tick += unit.WaitForTurn;
        }

        #region Option Members
        public void RunAway()
        {
            _timing.Stop();
            DenyEnemyTurns();
            CleanBattlefield();
            End();
        }

        public void SafeFreeze()
        {
            if (IsBattle)
                Freeze();
        }

        private protected virtual void Freeze()
        {
            _timing.Stop();
            DenyEnemyTurns();
        }

        public void Pause()
        {
            if (IsBattle)
                _timing.Stop();
        }

        public void Resume()
        {
            if (IsBattle)
                _timing.Start();
        }
        #endregion

        #endregion

        #region Enemy Members
        public bool IsBattle => Enemies.Count > 0;

        private ObservableCollection<Enemy> _enemies;
        public ObservableCollection<Enemy> Enemies
        {
            get => _enemies;
            set
            {
                _enemies = value;
                OnPropertyChanged();
            }
        }

        private void CleanBattlefield()
        {
            Enemies.Clear();
            OnPropertyChanged(nameof(Enemies));
            OnPropertyChanged(nameof(IsBattle));
        }

        public ushort EnemySpeed()
        {
            ushort overallSpeed = 0;
            for (byte i = 0; i < Enemies.Count; i++)
            {
                overallSpeed += Enemies[i].Unit.Stats.Speed;
            }
            return overallSpeed;
        }

        private protected void EnemyTurns()
        {
            for (byte i = 0; i < Enemies.Count; i++)
            {
                StartTurns(Enemies[i]);
                //Poison(Enemies[i]);
            }
        }

        private void DenyEnemyTurns()
        {
            for (byte i = 0; i < Enemies.Count; i++)
                EndTurns(Enemies[i]);
        }

        internal void EnemyDefeat(in Enemy enemy)
        {
            EndTurns(enemy);
            _ = Enemies.Remove(enemy);

            if (!IsBattle)
                Won();
        }
        #endregion

        public abstract void Start();
        private protected abstract void End();

        public abstract void Won();
        public abstract void Lose();

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