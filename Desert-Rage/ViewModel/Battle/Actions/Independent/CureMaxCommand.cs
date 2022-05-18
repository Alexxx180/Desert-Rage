using DesertRage.Model.Stats.Player;
using DesertRage.Model.Menu.Battle;

namespace DesertRage.ViewModel.Actions.Independent
{
    public class CureMaxCommand : ActCommand
    {
        public CureMaxCommand(IThing thing,
            Targeting cursor) : base(thing)
        {
            UnitCursor = cursor;
        }

        public CureMaxCommand(IThing thing) :
            this(thing, Targeting.HERO) { }

        protected UserProfile User => ViewModel.Player;
        protected Character Hero => User.Hero;

        private protected override void Use(object parameter)
        {
            Hero.Cure();
            User.UpdateHero();
            CheckStatus();
        }

        protected void CheckStatus()
        {
            System.Diagnostics.Trace.WriteLine("MAXED");
            System.Diagnostics.Trace.WriteLine(Hero.Hp.ToString());
        }
    }
}