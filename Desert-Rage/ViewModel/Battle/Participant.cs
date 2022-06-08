using DesertRage.Model.Locations.Battle.Stats;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle
{
    public abstract class Participant : Battle, INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        #region Timing Members
        private Bar _time;
        public Bar Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        private bool _isHit;
        public bool IsHit
        {
            get => _isHit;
            set
            {
                _isHit = value;
                OnPropertyChanged();
            }
        }

        private bool _isAct;
        public bool IsAct
        {
            get => _isAct;
            set
            {
                _isAct = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public abstract BattleUnit Unit { get; }

        private protected abstract void Damage(int value);
        private protected abstract void Defeat();

        public void Hit(in int value)
        {
            if (Unit.Hp.IsEmpty)
                return;

            IsHit = true;

            Damage(value);
            if (Unit.Hp.IsEmpty)
            {
                Defeat();
            }

            OnPropertyChanged(nameof(Unit));

            IsHit = false;
        }

        public virtual void WaitForTurn(object sender, object o)
        {
            if (Time.IsMax)
                return;

            ushort speed = 10;
            speed += Unit.Stats.Speed;

            Time = Time.Restore(speed);
        }
    }
}