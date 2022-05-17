using DesertRage.Model.Stats.Player;
using DesertRage.Model.Menu.Battle;

namespace DesertRage.ViewModel.Actions.Independent
{
    public class CureMaxCommand : ActCommand
    {
        public CureMaxCommand(IThing thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        private protected override void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            character.Cure();
            user.UpdateHero();

            System.Diagnostics.Trace.WriteLine("MAXED");
            System.Diagnostics.Trace.WriteLine(character.Hp.ToString());
        }
    }
}