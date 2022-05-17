using DesertRage.Customing.Converters;
using DesertRage.Model.Stats;
using DesertRage.ViewModel.Actions;

namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public class FightCommand : ActCommand
    {
        public FightCommand()
        {
            Cursor = Battle.Targeting.ONE;
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