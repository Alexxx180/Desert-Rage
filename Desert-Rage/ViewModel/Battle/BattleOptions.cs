using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace DesertRage.ViewModel.Battle
{
    public abstract class BattleOptions : INotifyPropertyChanged
    {
        private protected readonly DispatcherTimer _timing;

        private protected BattleOptions()
        {
            _timing = new DispatcherTimer();
            _timing.Interval = new TimeSpan(0, 0, 0, 0, 50);
            Enemies = new ObservableCollection<Enemy>();
        }

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
                _timing.Tick += Enemies[i].WaitForTurn;
        }

        private void DenyEnemyTurns()
        {
            for (byte i = 0; i < Enemies.Count; i++)
                EnemyTurnsOver(Enemies[i]);
        }

        private void EnemyTurnsOver(in Enemy enemy)
        {
            _timing.Tick -= enemy.WaitForTurn;
        }

        internal void EnemyDefeat(in Enemy enemy)
        {
            EnemyTurnsOver(enemy);
            _ = Enemies.Remove(enemy);

            if (!IsBattle)
                Won();
        }
        #endregion

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

        public abstract void Start();
        private protected abstract void End();

        public abstract void Won();
        public abstract void Lose();
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