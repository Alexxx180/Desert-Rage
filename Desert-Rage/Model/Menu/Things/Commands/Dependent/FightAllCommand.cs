using DesertRage.Customing.Converters;
using DesertRage.Model.Stats.Player;
using DesertRage.ViewModel;
using DesertRage.ViewModel.Actions;
using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public class FightAllCommand : ActCommand
    {
        public FightAllCommand()
        {
            Cursor = Battle.Targeting.ALL;
        }

        private protected override void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            int power = (character.Special * Subject.Power).ToInt();

            foreach (BattleUnit unit in ViewModel.Enemies)
                unit.Hit(power);

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(ViewModel.Player.Hero.Hp.ToString());
        }
    }
}