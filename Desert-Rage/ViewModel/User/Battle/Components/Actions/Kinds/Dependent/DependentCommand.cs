using System.ComponentModel;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class DependentCommand : ActCommand, INotifyPropertyChanged
    {
        public DependentCommand(IFormula statUnit)
        {
            StatUnit = statUnit;
        }
        
        /// <summary>
        /// Used for creating game
        /// environment dependent
        /// battle commands
        /// </summary>
        /// <param name="statUnit">Dependency formula</param>
        /// <param name="unit">Skill info</param>
        public DependentCommand(IFormula statUnit,
            NoiseUnit unit) : base(unit)
        {
            StatUnit = statUnit;
        }

        private IFormula _statUnit;
        public IFormula StatUnit
        {
            get => _statUnit;
            set
            {
                _statUnit = value;
                OnPropertyChanged();
            }
        }

        public override void SetModel(BattleViewModel model)
        {
            base.SetModel(model);
            StatUnit.SetModel(model);
            OnPropertyChanged(nameof(StatUnit));
        }
    }
}
