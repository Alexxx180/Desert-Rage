using System.ComponentModel;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class DependentCommand : ActCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Used for creating game
        /// environment dependent
        /// battle commands
        /// </summary>
    
        private static readonly string _formulaSpace;
    
        static DependentCommand()
        {
            Type formula = typeof(DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency.IFormula);
            _formulaSpace = formula.NameSpace;
        }

        public void SetUnit(AttributeUnit unit)
        {
            base.SetUnit(unit);
            DependencyID id = (DependencyID)unit.Attributes["Dependency"].Value
            string name = id.ToString();
            string full = $"{_formulaSpace}.{name}";
            
            IFormula formula = (IFormula)Activator.CreateInstance(full);
            formula.SetAttributes(unit.Attributes);
            StatUnit = formula;
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
