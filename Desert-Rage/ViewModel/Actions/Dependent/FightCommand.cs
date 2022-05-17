using DesertRage.Customing.Converters;
using DesertRage.Model.Stats;
using DesertRage.Model.Menu.Battle;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class FightCommand : ActCommand
    {
        public FightCommand(IThing thing) : base(thing)
        {
            UnitCursor = Targeting.ONE;
        }

        private protected override void Use(object parameter)
        {
            System.Diagnostics.Trace.WriteLine(parameter is null);
            System.Diagnostics.Trace.WriteLine(parameter.GetType().Name);
            System.Diagnostics.Trace.WriteLine(parameter.GetType().FullName);
            

            BattleUnit unit = parameter as BattleUnit;
            int power = Subject.Power.ToInt();
            unit.Hit(power);

            ViewModel.UpdateEnemies();

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(unit.Hp.ToString());
        }
    }
}