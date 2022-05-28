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

        public void Use(object parameter)
        {
            Act();

            Enemy unit = parameter as Enemy;
            int power = StatUnit.Power.ToInt();
            unit.Hit(power);

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(unit.Foe.Name);
            System.Diagnostics.Trace.WriteLine(unit.Foe.Hp.ToString());
        }

        public bool CanUse => ViewModel.IsBattle;
    }
}