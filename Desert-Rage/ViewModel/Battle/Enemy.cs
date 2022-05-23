﻿using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.ViewModel.Battle
{
    public class Enemy : INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        public Enemy(Foe foe)
        {
            Foe = foe;
            Time = new Bar(0, 1000);
            System.Diagnostics.Trace.WriteLine(foe.Stats.Speed);
        }

        public Enemy(BattleViewModel viewModel, Foe foe) : this(foe)
        {
            SetViewModel(viewModel);
        }

        private BattleViewModel _viewModel;
        public BattleViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        #region Foe Members
        private Foe _foe;
        public Foe Foe
        {
            get => _foe;
            set
            {
                _foe = value;
                OnPropertyChanged();
            }
        }

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
        #endregion

        public void SetViewModel
            (BattleViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Hit(in int value)
        {
            IsHit = true;

            Foe.Hit(value);
            if (Foe.Hp.IsEmpty)
            {
                _ = ViewModel.Enemies.Remove(this);
            }

            OnPropertyChanged(nameof(Foe));

            IsHit = false;
        }

        public void WaitForTurn()
        {
            ushort speed = 10;
            speed += Foe.Stats.Speed;

            Time = Time.Restore(speed);

            if (Time.IsMax)
            {
                Time = Time.Drain();
                Turn();
            }
        }

        private void Turn()
        {
            Attack();
        }

        private void Attack()
        {
            ushort attack = Foe.Stats.Attack;

            ViewModel.Player.Hero.Hit(attack);
            ViewModel.Player.UpdateHero();
        }

        public Position Tile { get; set; }

        

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