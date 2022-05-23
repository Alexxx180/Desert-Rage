using System.ComponentModel;
using DesertRage.Customing.Converters;
using DesertRage.Model;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Things;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class CureCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public CureCommand(
            IFormula dependency,
            NoiseUnit thing
            ) : base(dependency, thing)
        {
            UnitCursor = Targeting.HERO;
        }

        protected UserProfile User => ViewModel.Player;
        protected Character Hero => User.Hero;

        protected int Power => StatUnit.Power.ToInt();

        public virtual void Use(object parameter)
        {
            User.SoundPlayer.PlayNoise(Unit.Noise);
            Hero.Cure(Power);
            User.UpdateHero();
            CheckStatus();
        }

        protected void CheckStatus()
        {
            System.Diagnostics.Trace.WriteLine("CURE!");
            System.Diagnostics.Trace.WriteLine(Power);
            System.Diagnostics.Trace.WriteLine(Hero.Hp.ToString());
        }

        public virtual bool CanUse => true;
    }
}