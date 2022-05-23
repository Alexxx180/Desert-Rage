using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle;
using System.ComponentModel;
using DesertRage.Model;
using DesertRage.Model.Locations;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Independent
{
    public class CureMaxCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public CureMaxCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }
        
        protected UserProfile User => ViewModel.Player;
        protected Character Hero => User.Hero;

        public virtual void Use(object parameter)
        {
            User.SoundPlayer.PlayNoise(Unit.Noise);
            Hero.Cure();
            User.UpdateHero();
            CheckStatus();
        }

        protected void CheckStatus()
        {
            System.Diagnostics.Trace.WriteLine("MAXED");
            System.Diagnostics.Trace.WriteLine(Hero.Hp.ToString());
        }

        public virtual bool CanUse => true;
    }
}