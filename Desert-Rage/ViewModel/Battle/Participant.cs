using DesertRage.Model.Locations.Battle.Stats;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle
{
    public abstract class Participant : Battle, INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        private protected Participant()
        {
            Time = new Slider(0, 1000);
            OnPropertyChanged(nameof(Unit));
        }

        #region Timing Members
        private Slider _time;
        public Slider Time
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

        private bool _isPoisoned;
        public bool IsPoisoned
        {
            get => _isPoisoned;
            set
            {
                _isPoisoned = value;
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

        public void SetPoison(bool state)
        {
            IsPoisoned = state;
        }

        #region Time Events
        public virtual void Poison(object sender, object o)
        {
            System.Diagnostics.Trace.WriteLine("THAT'S NOT ALL RIGHT " + Unit.Hp.ToString());
            if (Unit.Hp.IsEmpty)
                return;
            

            //Unit.Hp = Unit.Hp.Drain(1);
            //if (Unit.Hp.IsEmpty)
            //{
            //    Defeat();
            //}

            //OnPropertyChanged(nameof(Unit));
        }

        public virtual void WaitForTurn(object sender, object o)
        {
            if (Time.IsMax)
                return;

            ushort speed = 10;
            speed += Unit.Stats.Speed;

            Time.Fill(speed);
        }
        #endregion
    }
}