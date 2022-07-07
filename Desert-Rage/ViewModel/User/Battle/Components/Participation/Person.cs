using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.ViewModel;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status;
using DesertRage.Model.Helpers;
using System.ComponentModel;
using System.Collections.Generic;
using Serilog;

namespace DesertRage.ViewModel.User.Battle.Components.Participation
{
    public class Person : Participant, INotifyPropertyChanged
    {
        /// <summary>
        /// Hero logic: options
        /// and player profile
        /// </summary>
        public Person(BattleViewModel viewModel,
            MapWorker player) : base()
        {
            Player = player;

            SetModel(viewModel);
            SetCommands();
        }

        #region Battle Commands
        private void SetCommands()
        {
            Log.Debug("Loading battle options...");
            Dictionary<string, AttributeUnit> options = Bank.GetBattleOptions();
            Fight = InstantCommand.FromUnit(options["Fight"]);
            Shield = InstantCommand.FromUnit(options["Shield"]);
            Flee = InstantCommand.FromUnit(options["Flee"]);
            Auto = InstantCommand.FromUnit(options["Auto"]);

            Shield.SetModel(ViewModel);
            Fight.SetModel(ViewModel);
            Flee.SetModel(ViewModel);
            Auto.SetModel(ViewModel);
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
        public MapWorker Player { get; }

        public override BattleUnit Unit => Player.Hero;

        public void Act()
        {
            IsAct = true;
            Time.Drain();
            IsAct = false;
        }

        public override void Berserk()
        {
            Act();
            if (ViewModel.IsBattle)
                Fight.Execute(ViewModel.Enemies[0]);
        }

        public void Cure(in int value)
        {
            Unit.Cure(value);
            Player.UpdateHero();
        }

        public void Rest(in int value)
        {
            Player.Hero.Rest(value);
            Player.UpdateHero();
        }
        #endregion

        #region Participant Members
        private protected override void Damage(int value)
        {
            Player.Hit(value);
        }

        private protected override void Defeat()
        {
            ViewModel.Lose();
        }
        #endregion

        public override void WaitForTurn(object sender, object o)
        {
            if (!Time.IsMax)
                base.WaitForTurn(sender, o);
        }
    }
}
