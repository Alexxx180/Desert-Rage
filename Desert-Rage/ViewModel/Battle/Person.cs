using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Resources.Media.OST.Noises.Actions;
using DesertRage.Resources.Media.OST.Noises.Weapons;
using DesertRage.ViewModel.Battle.Actions;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.Battle.Actions.Kinds.Independent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.Battle
{
    public class Person : INotifyPropertyChanged
    {
        public Person
            (BattleViewModel viewModel, UserProfile player)
        {
            Player = player;
            Time = new Bar(0, 1000);
            SetViewModel(viewModel);
            SetCommands();
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

        #region Battle Commands
        private void SetCommands()
        {
            Fight = new InstantCommand(
                new FightCommand(
                    new AttackFormula(0),
                    new NoiseUnit("Пустой слот")
                    {
                        Name = "Пусто",
                        Noise = WeaponNoises.Punch
                    }
                )
            );

            Shield = new InstantCommand(
                new StatusCommand(StatusID.DEFENCE, true,
                    new NoiseUnit()
                    {
                        Noise = ActionNoises.DefenceBoost
                    }
                )
            );

            Flee = new InstantCommand(
                new EscapeCommand(
                    new SpeedFormula(),
                    new NoiseUnit()
                    {
                        Noise = ActionNoises.Flee
                    }
                )
            );

            Auto = new InstantCommand(
                new StatusCommand(StatusID.BERSERK, true,
                    new NoiseUnit()
                    {
                        Noise = ActionNoises.PowerBoost
                    }
                )
            );

            Shield.SetViewModel(ViewModel);
            Fight.SetViewModel(ViewModel);
            Flee.SetViewModel(ViewModel);
            Auto.SetViewModel(ViewModel);
        }

        private InstantCommand _fight;
        public InstantCommand Fight
        {
            get => _fight;
            set
            {
                _fight = value;
                OnPropertyChanged();
            }
        }

        private InstantCommand _shield;
        public InstantCommand Shield
        {
            get => _shield;
            set
            {
                _shield = value;
                OnPropertyChanged();
            }
        }

        private InstantCommand _flee;
        public InstantCommand Flee
        {
            get => _flee;
            set
            {
                _flee = value;
                OnPropertyChanged();
            }
        }

        private InstantCommand _auto;
        public InstantCommand Auto
        {
            get => _auto;
            set
            {
                _auto = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Hero Members
        private UserProfile _player;
        public UserProfile Player
        {
            get => _player;
            set
            {
                _player = value;
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

        public void Act()
        {
            IsAct = true;
            IsAct = false;
        }
        #endregion

        #region Dependency Members
        public void SetViewModel
            (BattleViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Cure(in int value)
        {
            Player.Hero.Cure(value);
            Player.UpdateHero();
        }

        public void Rest(in int value)
        {
            Player.Hero.Rest(value);
            Player.UpdateHero();
        }

        public void Hit(in int value)
        {
            if (Player.Hero.Hp.IsEmpty)
                return;

            IsHit = true;

            Player.Hero.Hit(value);
            if (Player.Hero.Hp.IsEmpty)
            {
                ViewModel.Lose();
            }

            Player.UpdateHero();

            IsHit = false;
        }
        #endregion

        public void WaitForTurn(object sender, object o)
        {
            if (Time.IsMax)
                return;

            ushort speed = 10;
            speed += Player.Hero.Stats.Speed;

            Time = Time.Restore(speed);
        }

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