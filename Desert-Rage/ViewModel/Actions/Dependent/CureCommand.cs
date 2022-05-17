using System.ComponentModel;
using DesertRage.Customing.Converters;
using DesertRage.Model.Menu.Battle;
using DesertRage.Model.Stats.Player;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class CureCommand : ActCommand, INotifyPropertyChanged
    {
        public CureCommand(IThing thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        private protected override void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            int power = Subject.Power.ToInt();

            character.Cure(power);
            user.UpdateHero();

            System.Diagnostics.Trace.WriteLine(power);
            System.Diagnostics.Trace.WriteLine(character.Hp.ToString());
        }
    }
}