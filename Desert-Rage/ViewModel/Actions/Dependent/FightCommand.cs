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
            BattleUnit unit = parameter as BattleUnit;
            int power = Subject.Power.ToInt();
            unit.Hit(power);

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(ViewModel.Player.Hero.Hp.ToString());
        }
    }
}