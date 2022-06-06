using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class FightCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public FightCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.ONE;
        }

        protected int Power => StatUnit.Power.ToInt();

        protected void Damage(in Enemy unit)
        {
            unit.Hit(Power);
        }

        public virtual void Use(object parameter)
        {
            Act();
            Damage(parameter as Enemy);
        }

        public bool CanUse => ViewModel.IsBattle;
    }
}