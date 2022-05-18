using System.ComponentModel;
using DesertRage.Customing.Converters;
using DesertRage.Model.Menu.Battle;
using DesertRage.Model.Stats.Player;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class CureCommand : ActCommand, INotifyPropertyChanged
    {
        public CureCommand(IThing thing,
            Targeting cursor) : base(thing)
        {
            UnitCursor = cursor;
        }

        public CureCommand(IThing thing) :
            this(thing, Targeting.HERO) { }

        protected UserProfile User => ViewModel.Player;
        protected Character Hero => User.Hero;

        protected int Power => Subject.Power.ToInt();

        private protected override void Use(object parameter)
        {
            Hero.Cure(Power);
            User.UpdateHero();
            CheckStatus();
        }

        protected void CheckStatus()
        {
            System.Diagnostics.Trace.WriteLine(Power);
            System.Diagnostics.Trace.WriteLine(Hero.Hp.ToString());
        }
    }
}