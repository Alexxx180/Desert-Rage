using DesertRage.Customing.Converters;
using DesertRage.Model.Stats;
using DesertRage.Model.Menu.Battle;
using System.ComponentModel;
using DesertRage.ViewModel.Battle;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class FightCommand : ActCommand, INotifyPropertyChanged
    {
        public FightCommand(IThing thing) : base(thing)
        {
            UnitCursor = Targeting.ONE;
        }

        private protected override void Use(object parameter)
        {
            Enemy unit = parameter as Enemy;
            int power = Subject.Power.ToInt();
            unit.Hit(power);

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(unit.Foe.Name);
            System.Diagnostics.Trace.WriteLine(unit.Foe.Hp.ToString());
        }
    }
}