using DesertRage.Model.Stats.Player;
using DesertRage.ViewModel;
using DesertRage.ViewModel.Actions;

namespace DesertRage.Model.Menu.Things.Commands.Independent
{
    public class CureMaxCommand : ActCommand
    {
        public CureMaxCommand()
        {
            Cursor = Battle.Targeting.HERO;
        }

        private protected override void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            character.Cure();
            user.UpdateHero();

            System.Diagnostics.Trace.WriteLine("MAXED");
            System.Diagnostics.Trace.WriteLine(ViewModel.Player.Hero.Hp.ToString());
        }
    }
}