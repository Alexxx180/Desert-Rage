using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle;
using System.ComponentModel;
using DesertRage.Model;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Independent
{
    public class CureMaxCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public CureMaxCommand(DescriptionUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }
        
        protected UserProfile User => ViewModel.Player;
        protected Character Hero => User.Hero;

        public virtual void Use(object parameter)
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