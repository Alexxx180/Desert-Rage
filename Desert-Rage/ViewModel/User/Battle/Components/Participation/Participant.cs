﻿using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.ViewModel.User.Battle.Components.Participation.Statuses;
using System.Collections.Generic;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Participation
{
    public abstract class Participant : Battle, INotifyPropertyChanged
    {
        /// <summary>
        /// Battle participant logic:
        /// timing and statuses
        /// </summary>
        private protected Participant()
        {
            Time = new Slider(0, 1000);
            StatusEvents = new Dictionary<StatusID, IStatusEvent>
            {
                { StatusID.POISON, new Poison(this) },
                { StatusID.REINFORCEMENT, new Reinforcement
                    (this, StatusID.REINFORCEMENT) },
                { StatusID.SHIELD, new Reinforcement
                    (this, StatusID.SHIELD) },
                { StatusID.DEFENCE, new Reinforcement
                    (this, StatusID.DEFENCE) },
                { StatusID.BERSERK, new Berserk(this) },
                { StatusID.SPEEDUP, new Reinforcement
                    (this, StatusID.SPEEDUP) }
            };
        }

        protected internal void SavedEvents()
        {
            AddEvent(StatusID.POISON);
            AddEvent(StatusID.REINFORCEMENT);
            AddEvent(StatusID.SHIELD);
            AddEvent(StatusID.DEFENCE);
            AddEvent(StatusID.BERSERK);
            AddEvent(StatusID.SPEEDUP);
        }

        private void AddEvent(StatusID id)
        {
            if (!Unit.NoStatus(id.Int()))
                ViewModel.AddStateEvent(StatusEvents[id]);
        }

        internal void ApplyEvent(StatusID id)
        {
            if (Unit.NoStatus(id.Int()))
                ViewModel.AddStateEvent(StatusEvents[id]);
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

        private bool _isTurn;
        public bool IsTurn
        {
            get => _isTurn;
            set
            {
                _isTurn = value;
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
        public abstract void Berserk();

        #region Damage Members
        private protected abstract void Damage(int value);
        private protected abstract void Defeat();

        public bool IsDead => Unit.Hp.IsEmpty;

        public void Hit(in int value)
        {
            if (IsDead)
                return;

            IsHit = true;

            Damage(value);
            SafeDefeat();

            IsHit = false;
        }

        public void ToughHit(in ushort value)
        {
            if (IsDead)
                return;

            Unit.Hp.Drain(value);
            SafeDefeat();
        }

        private void SafeDefeat()
        {
            if (IsDead)
            {
                Defeat();
            }
        }

        public void Annihilate()
        {
            Unit.Annihilate();
            Defeat();
        }
        #endregion

        #region Time Events
        public bool NoStatus(StatusID id)
        {
            Slider status = Unit.StatusInfo[id.Int()].Time;
            status.Drain(1);

            return status.IsEmpty;
        }

        public virtual void WaitForTurn(object sender, object o)
        {
            if (Time.IsMax)
                return;

            float totalSpeed = ViewModel.Human.Player.Preferences.BattleSpeed.Current;

            float speed = 0.8f;
            speed *= Unit.BattleSpeed;
            speed *= totalSpeed;

            totalSpeed *= 0.2f;
            totalSpeed += speed;
            totalSpeed *= Unit.Boost(StatusID.SPEEDUP);

            Time.Fill(totalSpeed.ToUShort());
            if (Time.IsMax)
                IsTurn = true;
        }
        #endregion

        public readonly Dictionary<StatusID, IStatusEvent> StatusEvents;
    }
}
