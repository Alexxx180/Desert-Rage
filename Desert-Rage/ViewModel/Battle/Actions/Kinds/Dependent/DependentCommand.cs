using System.ComponentModel;
using DesertRage.Model;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class DependentCommand : ActCommand, INotifyPropertyChanged
    {
        public DependentCommand(IFormula statUnit,
            DescriptionUnit unit) : base(unit)
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
            System.Diagnostics.Trace.WriteLine("OH YEAH");

            base.SetViewModel(viewModel);
            StatUnit.SetViewModel(viewModel);
            OnPropertyChanged(nameof(StatUnit));
        }
    }
}