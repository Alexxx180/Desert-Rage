using System.ComponentModel;
using DesertRage.Model.Locations;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class DependentCommand : ActCommand, INotifyPropertyChanged
    {
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

        public override void SetViewModel(BattleViewModel viewModel)
        {
            base.SetViewModel(viewModel);
            StatUnit.SetViewModel(viewModel);
            OnPropertyChanged(nameof(StatUnit));
        }
    }
}