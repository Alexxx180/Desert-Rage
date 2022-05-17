using DesertRage.Customing.Converters;
using DesertRage.Model.Stats.Player;
using DesertRage.ViewModel;
using DesertRage.ViewModel.Actions;
using System.ComponentModel;

namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public class CureCommand : ActCommand, INotifyPropertyChanged
    {
        public CureCommand()
        {
            Cursor = Battle.Targeting.HERO;
        }

        private protected override void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            int power = Subject.Power.ToInt();

            character.Cure(power);
            user.UpdateHero();

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(ViewModel.Player.Hero.Hp.ToString());
        }
    }
}